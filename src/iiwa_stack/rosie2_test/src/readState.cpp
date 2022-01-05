#include "ros/ros.h"
#include "std_msgs/String.h"
#include <sensor_msgs/JointState.h>
#include <iostream>
#include <string>
#include <moveit/move_group_interface/move_group_interface.h>
#include <moveit/planning_scene_interface/planning_scene_interface.h>
//#include "rosie2_test/PlanSrv.h"

#include <moveit_msgs/DisplayRobotState.h>

#include <moveit_msgs/AttachedCollisionObject.h>
#include <moveit_msgs/CollisionObject.h>

#include <moveit_visual_tools/moveit_visual_tools.h>

#include <vector>

bool new_gl_rcvd = false;
std::vector<geometry_msgs::Pose> pose_goals; 
ros::Publisher traj_feedback;





void goal_list_subscriber_callback(const geometry_msgs::PoseArray::ConstPtr& msg)
{
  pose_goals.clear();
  for(int i=0;i<msg->poses.size();i++){
    pose_goals.push_back(msg->poses[i]);
  }
  new_gl_rcvd = true;
  
}

void excecute_trajectory(moveit::planning_interface::MoveGroupInterface& move_group, moveit::planning_interface::MoveGroupInterface::Plan& my_plan)
{

  move_group.setMaxVelocityScalingFactor(0.1);

  moveit_msgs::RobotTrajectory trajectory;
  const double jump_threshold = 0.0;
  const double eef_step = 0.01;
  double fraction = move_group.computeCartesianPath(pose_goals, eef_step, jump_threshold, trajectory);
  std_msgs::String feedback_str;
  feedback_str.data = "Received trajectory from Unity (Cartesian path) ("+ std::to_string(fraction * 100.0) + "% acheived)" ;
  traj_feedback.publish(feedback_str);

  my_plan.trajectory_= trajectory;
  move_group.execute(my_plan);
    
}


bool new_pl_rcvd = false;
std::vector<geometry_msgs::Pose> plan_goals; 

void plan_list_subscriber_callback(const geometry_msgs::PoseArray::ConstPtr& msg)
{
  plan_goals.clear();
  for(int i=0;i<msg->poses.size();i++){
    plan_goals.push_back(msg->poses[i]);
    std::cout << msg->poses[i];
  }
  new_pl_rcvd = true;
  
}

void plan_trajectory(moveit::planning_interface::MoveGroupInterface& move_group, moveit::planning_interface::MoveGroupInterface::Plan& my_plan)
{

  move_group.setMaxVelocityScalingFactor(0.1);

  moveit_msgs::RobotTrajectory trajectory;
  const double jump_threshold = 0.0;
  const double eef_step = 0.01;
  double fraction = move_group.computeCartesianPath(plan_goals, eef_step, jump_threshold, trajectory);
  ROS_INFO("Received trajectory from Unity (Cartesian path) (%.2f%% acheived)", fraction * 100.0);

  my_plan.trajectory_= trajectory;
  move_group.plan(my_plan);
    
}



int main(int argc, char **argv)
{
 
  ros::init(argc, argv, "move_group_interface_tutorial");
  ros::NodeHandle node_handle;

  ros::Subscriber sub_goal_list = node_handle.subscribe("/goal_poses", 1000, goal_list_subscriber_callback);
  ros::Subscriber sub_plan_list = node_handle.subscribe("/plan_poses", 1000, plan_list_subscriber_callback);
  traj_feedback = node_handle.advertise<std_msgs::String>("trajectory_feedback", 1000);

  ros::AsyncSpinner spinner(1);
  spinner.start(); 

  static const std::string PLANNING_GROUP = "manipulator";


  moveit::planning_interface::MoveGroupInterface move_group(PLANNING_GROUP);

  moveit::planning_interface::PlanningSceneInterface planning_scene_interface;


  const robot_state::JointModelGroup* joint_model_group =  move_group.getCurrentState()->getJointModelGroup(PLANNING_GROUP);
  
  moveit::planning_interface::MoveGroupInterface::Plan my_plan;
  


  

  //rosie2_test::PlanSrv srv;

   while(ros::ok){
  

     if(new_gl_rcvd)
     {
       new_gl_rcvd = false;
       excecute_trajectory(move_group, my_plan);
     }
     if(new_pl_rcvd)
     {
       new_pl_rcvd = false;
       plan_trajectory(move_group, my_plan);
     }

      // ros::spin();
  }
  

  
  return 0;
}



// x: -0.159703038639
//     y: 0.778446685214
//     z: 2.12785238828
//   orientation: 
//     x: -1.48251074356e-05
//     y: -4.98372381145e-05
//     z: 0.707052211016
//     w: 0.707161345234 