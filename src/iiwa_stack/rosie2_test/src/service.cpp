#include "ros/ros.h"
#include <moveit/move_group_interface/move_group_interface.h>
#include "rosie2_test/PlanSrv.h"
#include "geometry_msgs/Pose.h"
#include "geometry_msgs/PoseStamped.h"
#include "std_msgs/String.h"


std::vector<geometry_msgs::Pose> trjacteory_message(rosie2_test::PlanSrv::Request  &req, geometry_msgs::PoseStamped currentPose) 
{
    std::vector<geometry_msgs::Pose> trajectory_goal;
    trajectory_goal.clear();
    trajectory_goal.push_back(currentPose.pose);
    for (int i=0; i<req.pose_goal.poses.size(); i++)
    {
        trajectory_goal.push_back(req.pose_goal.poses[i]);
    }
    return trajectory_goal;

} 

bool plan_motion_service(rosie2_test::PlanSrv::Request  &req, rosie2_test::PlanSrv::Response &res)
{
    
    moveit::planning_interface::MoveGroupInterface::Plan my_plan;
    ROS_INFO("Planning request received");

    static const std::string PLANNING_GROUP = "manipulator";
    moveit::planning_interface::MoveGroupInterface move_group(PLANNING_GROUP);
    bool success;

    

    if(req.pose_goal.poses.size()==1)
    {
        move_group.setPoseTarget(req.pose_goal.poses[0]);
        std::cout << "For debugging only" << std::endl;
        std::cout << req.pose_goal.poses[0] << std::endl;
        success = (move_group.plan(my_plan) == moveit::planning_interface::MoveItErrorCode::SUCCESS);
        if(!req.plan){
            success = (move_group.move() == moveit::planning_interface::MoveItErrorCode::SUCCESS);
            //move_group.stop();
        } 
        std_msgs::String feedback_str;
        feedback_str.data = "Received pose goal from Unity";
        if(!success)
        {
            feedback_str.data = feedback_str.data + ": FAILED to execute motion";
        }
        res.feedback = feedback_str;
        return true;   
    }
    else if (req.pose_goal.poses.size()>1)
    {
        move_group.setMaxVelocityScalingFactor(0.1);
        
        moveit_msgs::RobotTrajectory trajectory;
        const double jump_threshold = 0.0;
        const double eef_step = 0.01;
        geometry_msgs::PoseStamped currentPose = move_group.getCurrentPose();
        double fraction = move_group.computeCartesianPath(trjacteory_message(req, currentPose), eef_step, jump_threshold, trajectory);
        std_msgs::String feedback_str;
        feedback_str.data = "Received trajectory from Unity (Cartesian path) ("+ std::to_string(fraction * 100.0) + "% acheived)" ;
        my_plan.trajectory_= trajectory;
        if(!req.plan)
             move_group.execute(my_plan);
        res.feedback = feedback_str;
        return true;  
    }
    
}

int main(int argc, char **argv)
{
    ros::init(argc, argv, "plan_motion_node");
    ros::NodeHandle n;

    ros::AsyncSpinner spinner(2);
    spinner.start(); 

    ros::ServiceServer service = n.advertiseService("planService", &plan_motion_service);

    ROS_INFO("Ready to receive planning request");
    while(ros::ok){

    
    }

    return 0;
}