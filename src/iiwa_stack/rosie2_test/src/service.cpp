#include "ros/ros.h"
#include <moveit/move_group_interface/move_group_interface.h>
#include "rosie2_test/PlanSrv.h"
#include "geometry_msgs/Pose.h"

  

bool plan_motion_service(rosie2_test::PlanSrv::Request  &req, rosie2_test::PlanSrv::Response &res)
{
    ROS_INFO("Planning request received");

    
static const std::string PLANNING_GROUP = "manipulator";
moveit::planning_interface::MoveGroupInterface move_group(PLANNING_GROUP);

    if(req.pose_goal.poses.size()==1)
    {
        move_group.setPoseTarget(req.pose_goal.poses[0]);
        move_group.move();
        move_group.stop();
        ROS_INFO("Done with motion");
        res.success = true;
        return true;
    }
    
}

int main(int argc, char **argv)
{
    ros::init(argc, argv, "plan_motion_node");
    ros::NodeHandle n;
    // ros::Duration duration(0.1);
    // duration.sleep();

    ros::AsyncSpinner spinner(2);
    spinner.start(); 

    ros::ServiceServer service = n.advertiseService("planService", &plan_motion_service);
    ROS_INFO("Ready to receive planning request");
    while(ros::ok){

    
    }

    return 0;
}