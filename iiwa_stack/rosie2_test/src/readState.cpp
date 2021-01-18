#include "ros/ros.h"
#include "std_msgs/String.h"
#include <sensor_msgs/JointState.h>
#include <iostream>
#include <string>
#include <moveit/move_group_interface/move_group_interface.h>
#include <moveit/planning_scene_interface/planning_scene_interface.h>

#include <moveit_msgs/DisplayRobotState.h>
#include <moveit_msgs/DisplayTrajectory.h>

#include <moveit_msgs/AttachedCollisionObject.h>
#include <moveit_msgs/CollisionObject.h>

#include <moveit_visual_tools/moveit_visual_tools.h>

#include <dynamic_reconfigure/Reconfigure.h>
#include <dynamic_reconfigure/IntParameter.h>
#include <vector>

  /***********************************************************
   * Test: Subscibe to unity sphere position and move around
   **********************************************************/
geometry_msgs::PoseStamped sphere_pose, old_sphere_pose;
//geometry_msgs::PoseArray PoseArray;
std::vector<geometry_msgs::Pose> pose_goals; 
void test_sphere_position_callback(const geometry_msgs::PoseStamped::ConstPtr& msg){
    
    sphere_pose = *msg;
}
  /***********************************************************
   * Test: Subscibe to unity sphere trajectory
   **********************************************************/

void goal_list_subscriber_callback(const geometry_msgs::PoseArray::ConstPtr& msg){
  pose_goals.clear();
  for(int i=0;i<msg->poses.size();i++){
    pose_goals.push_back(msg->poses[i]);
  }
}

/***********************************************************
   * Test: Follow sphere continuosly
   **********************************************************/
void follow_sphere(moveit::planning_interface::MoveGroupInterface& move_group, moveit::planning_interface::MoveGroupInterface::Plan& my_plan, const robot_state::JointModelGroup* joint_model_group, moveit_visual_tools::MoveItVisualTools& visual_tools){

    ros::Duration(0.5).sleep();
    if(sphere_pose.pose != old_sphere_pose.pose){
        ROS_INFO("sphere has been moved?");
        move_group.setPoseTarget(sphere_pose);
        move_group.plan(my_plan);
        visual_tools.publishTrajectoryLine(my_plan.trajectory_, joint_model_group);
        visual_tools.trigger();
        move_group.execute(my_plan.trajectory_);
        ros::Duration(0.5).sleep();
        old_sphere_pose.pose = sphere_pose.pose;
        std::cout << old_sphere_pose.pose;
    }
    
}
/********************************************************************
 * Test: Create service to change n of waypoints
 * ******************************************************************/

void set_waypoints_c_srv(ros::NodeHandle& node_handle, int min_waypoint)
{
    dynamic_reconfigure::ReconfigureRequest srv_req;
    dynamic_reconfigure::ReconfigureResponse srv_resp;
    dynamic_reconfigure::IntParameter intPmin, intPmax;
    dynamic_reconfigure::Config config;

    intPmin.name = "minimum_waypoint_count";
    intPmin.value = min_waypoint;
    config.ints.push_back(intPmin);

    srv_req.config = config;
    ros::service::call("/iiwa/move_group/ompl/set_parameters", srv_req, srv_resp);
    std::cout << srv_resp << std::endl;

}




int main(int argc, char **argv)
{
 
  ros::init(argc, argv, "move_group_interface_tutorial");
  ros::NodeHandle node_handle;

  set_waypoints_c_srv(node_handle, 2);


  //ros::Subscriber sub_unity_sphere = node_handle.subscribe("/test_sphere_position", 1000, test_sphere_position_callback);
  ros::Subscriber sub_goal_list = node_handle.subscribe("/goal_poses", 1000, goal_list_subscriber_callback);

  ros::AsyncSpinner spinner(1);
  spinner.start(); 

  static const std::string PLANNING_GROUP = "manipulator";


  moveit::planning_interface::MoveGroupInterface move_group(PLANNING_GROUP);
  moveit::planning_interface::PlanningSceneInterface planning_scene_interface;

  const robot_state::JointModelGroup* joint_model_group =
      move_group.getCurrentState()->getJointModelGroup(PLANNING_GROUP);

  
  
  geometry_msgs::PoseStamped target_pose1 = move_group.getCurrentPose();
  //std::cout << target_pose1 << std::endl;
  
  //std::cout<< move_group.getCurrentJointValues();
  moveit::core::RobotStatePtr current_state = move_group.getCurrentState();

  namespace rvt = rviz_visual_tools;
  moveit_visual_tools::MoveItVisualTools visual_tools("world");
  visual_tools.deleteAllMarkers();

  
  // Next get the current set of joint values for the group.
  std::vector<double> joint_group_positions;
  current_state->copyJointGroupPositions(joint_model_group, joint_group_positions);

  // std::cout << joint_group_positions[0] << std::endl;
  // std::cout << joint_group_positions[1] << std::endl;
  // std::cout << joint_group_positions[2] << std::endl;
  // std::cout << joint_group_positions[3] << std::endl;
  // std::cout << joint_group_positions[4] << std::endl;
  // std::cout << joint_group_positions[5] << std::endl;
  // std::cout << joint_group_positions[6] << std::endl;


  joint_group_positions[0] = 0;
  joint_group_positions[1] = 0;
  joint_group_positions[2] = 0;
  joint_group_positions[3] = 0;
  joint_group_positions[4] = 0;
  joint_group_positions[5] = 0;
  joint_group_positions[6] = 0;

  move_group.setJointValueTarget(joint_group_positions);
  move_group.move();
  ROS_INFO("Moving to 0 position and waiting 5 seconds");
  ros::Duration(5).sleep();


  Eigen::Isometry3d text_pose = Eigen::Isometry3d::Identity();
  // text_pose.translation().z() = target_pose1.pose.position.z + 0.1;
  // visual_tools.publishText(text_pose, "Testing text!", rvt::WHITE, rvt::XLARGE);
  //ros::Duration(10).sleep();
  // visual_tools.trigger();

  // move_group.setPoseTarget(target_pose1.pose);
  
  moveit::planning_interface::MoveGroupInterface::Plan my_plan;
  
  // bool success = (move_group.plan(my_plan) == moveit::planning_interface::MoveItErrorCode::SUCCESS);
  // ROS_INFO_NAMED("tutorial", "Visualizing plan 1 as trajectory line");
  // visual_tools.publishAxisLabeled(target_pose1.pose, "pose1");
  // visual_tools.publishText(text_pose, "Pose Goal", rvt::WHITE, rvt::XLARGE);
  // visual_tools.publishTrajectoryLine(my_plan.trajectory_, joint_model_group);
  // std::cout << my_plan.trajectory_ << std::endl;
  // visual_tools.trigger();

  //ROS_INFO_NAMED("tutorial", "Visualizing plan 1 (pose goal) %s", success ? "" : "FAILED");

  // move_group.execute(my_plan.trajectory_);
  // ros::Duration(10).sleep();
  // ROS_INFO("Going back to initial position and waiting 10 seconds");

  //geometry_msgs::Pose target_pose3 = move_group.getCurrentPose().pose;

  std::vector<geometry_msgs::Pose> waypoints;
  
  move_group.setMaxVelocityScalingFactor(0.1);

  moveit_msgs::RobotTrajectory trajectory;
  const double jump_threshold = 0.0;
  const double eef_step = 0.01;
  double fraction = move_group.computeCartesianPath(pose_goals, eef_step, jump_threshold, trajectory);
  ROS_INFO_NAMED("tutorial","Visualizing plan 4 (Cartesian path) (%.2f%% acheived)", fraction * 100.0);



  visual_tools.deleteAllMarkers();
  visual_tools.publishText(text_pose, "Joint Space Goal", rvt::WHITE, rvt::XLARGE);
  visual_tools.publishPath(waypoints, rvt::LIME_GREEN, rvt::SMALL);
  for (std::size_t i = 0; i < pose_goals.size(); ++i)
    visual_tools.publishAxisLabeled(pose_goals[i], "pt" + std::to_string(i), rvt::SMALL);
  visual_tools.trigger();
  //visual_tools.prompt("Press 'next' in the RvizVisualToolsGui window to continue the demo");
  ros::Duration(5).sleep();


  my_plan.trajectory_= trajectory;
  move_group.execute(my_plan);
  ros::Duration(10).sleep();

   /*while(ros::ok){

      //follow_sphere(move_group, my_plan, joint_model_group, visual_tools);
      //std::cout <<PoseArray;
      ros::Duration(1).sleep();
      std::cout << pose_goals[0];
      
  }*/

  
  return 0;
}

