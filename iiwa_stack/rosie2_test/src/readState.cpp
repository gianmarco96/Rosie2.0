#include "ros/ros.h"
#include "std_msgs/String.h"
#include <sensor_msgs/JointState.h>
#include <iostream>
#include <string>
#include <moveit/move_group_interface/move_group_interface.h>
#include <moveit/planning_scene_interface/planning_scene_interface.h>

#include <moveit_msgs/DisplayRobotState.h>

#include <moveit_msgs/AttachedCollisionObject.h>
#include <moveit_msgs/CollisionObject.h>

#include <moveit_visual_tools/moveit_visual_tools.h>

#include <vector>

bool new_gl_rcvd = false;
std::vector<geometry_msgs::Pose> pose_goals; 

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
  ROS_INFO("Received trajectory from Unity (Cartesian path) (%.2f%% acheived)", fraction * 100.0);

  my_plan.trajectory_= trajectory;
  move_group.execute(my_plan);
    
}


int main(int argc, char **argv)
{
 
  ros::init(argc, argv, "move_group_interface_tutorial");
  ros::NodeHandle node_handle;

  ros::Subscriber sub_goal_list = node_handle.subscribe("/goal_poses", 1000, goal_list_subscriber_callback);

  ros::AsyncSpinner spinner(1);
  spinner.start(); 

  static const std::string PLANNING_GROUP = "manipulator";


  moveit::planning_interface::MoveGroupInterface move_group(PLANNING_GROUP);

  moveit::planning_interface::PlanningSceneInterface planning_scene_interface;


  const robot_state::JointModelGroup* joint_model_group =  move_group.getCurrentState()->getJointModelGroup(PLANNING_GROUP);
  
  moveit::planning_interface::MoveGroupInterface::Plan my_plan;
  



   while(ros::ok){
     if(new_gl_rcvd)
     {
       new_gl_rcvd = false;
       excecute_trajectory(move_group, my_plan);
     }

      
  }

  
  return 0;
}

