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

  /***********************************************************
   * Test: Subscibe to unity sphere position and move around
   **********************************************************/
geometry_msgs::PoseStamped sphere_pose, old_sphere_pose;

void test_sphere_position_callback(const geometry_msgs::PoseStamped::ConstPtr& msg){
    
    sphere_pose = *msg;
    //sphere_pose.pose.orientation.y = -msg->pose.orientation.y; 
    //std::cout << sphere_pose.pose << std::endl;
}

/***********************************************************
   * Test: Follow sphere continously
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

        // Function to set number of set points
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

  set_waypoints_c_srv(node_handle, 50);


  /*std::cout << "ouuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu" << std::endl;
  std::cout << "Size is:" << srv.request.config.ints.size() << std::endl;
    if (client.call(srv))
  {
      std::cout << srv.response << std::endl;
  }
  else
  {
      std::cout << "service not called" << std::endl;
  }*/

  //std::string = ""
//   srv.request.config.ints[0].name = "minimum_waypoint_count";



  /***********************************************************
   * Test: Subscibe to unity sphere position and move around
   **********************************************************/
  ros::Subscriber sub_unity_sphere = node_handle.subscribe("/test_sphere_position", 1000, test_sphere_position_callback);

  ros::AsyncSpinner spinner(1);
  spinner.start(); 

  static const std::string PLANNING_GROUP = "manipulator";


  moveit::planning_interface::MoveGroupInterface move_group(PLANNING_GROUP);
  moveit::planning_interface::PlanningSceneInterface planning_scene_interface;

  const robot_state::JointModelGroup* joint_model_group =
      move_group.getCurrentState()->getJointModelGroup(PLANNING_GROUP);
  
  geometry_msgs::PoseStamped target_pose1 = move_group.getCurrentPose();
  
  //std::cout<< move_group.getCurrentJointValues();
  moveit::core::RobotStatePtr current_state = move_group.getCurrentState();

  namespace rvt = rviz_visual_tools;
  moveit_visual_tools::MoveItVisualTools visual_tools("world");
  visual_tools.deleteAllMarkers();

  //
  // Next get the current set of joint values for the group.
  std::vector<double> joint_group_positions;
  current_state->copyJointGroupPositions(joint_model_group, joint_group_positions);

  std::cout << joint_group_positions[0] << std::endl;
  std::cout << joint_group_positions[1] << std::endl;
  std::cout << joint_group_positions[2] << std::endl;
  std::cout << joint_group_positions[3] << std::endl;
  std::cout << joint_group_positions[4] << std::endl;
  std::cout << joint_group_positions[5] << std::endl;
  std::cout << joint_group_positions[6] << std::endl;


  joint_group_positions[0] = 0;
  joint_group_positions[1] = 0;
  joint_group_positions[2] = 0;
  joint_group_positions[3] = 0;
  joint_group_positions[4] = 0;
  joint_group_positions[5] = 0;
  joint_group_positions[6] = 0;

  move_group.setJointValueTarget(joint_group_positions);
  move_group.move();
  ROS_INFO("Moving to 0 position and waiting 10 seconds");
  //ros::Duration(5).sleep();


  Eigen::Isometry3d text_pose = Eigen::Isometry3d::Identity();
  text_pose.translation().z() = target_pose1.pose.position.z + 0.1;
  visual_tools.publishText(text_pose, "Porco DIO!", rvt::WHITE, rvt::XLARGE);
  //ros::Duration(10).sleep();
  visual_tools.trigger();

  move_group.setPoseTarget(target_pose1.pose);
  
  moveit::planning_interface::MoveGroupInterface::Plan my_plan;
  bool success = (move_group.plan(my_plan) == moveit::planning_interface::MoveItErrorCode::SUCCESS);
  ROS_INFO_NAMED("tutorial", "Visualizing plan 1 as trajectory line");
  visual_tools.publishAxisLabeled(target_pose1.pose, "pose1");
  visual_tools.publishText(text_pose, "Pose Goal", rvt::WHITE, rvt::XLARGE);
  visual_tools.publishTrajectoryLine(my_plan.trajectory_, joint_model_group);
  std::cout << my_plan.trajectory_ << std::endl;
  visual_tools.trigger();

  ROS_INFO_NAMED("tutorial", "Visualizing plan 1 (pose goal) %s", success ? "" : "FAILED");

  move_group.execute(my_plan.trajectory_);
  ROS_INFO("Going back to initial position and waiting 10 seconds");

  /* while(ros::ok){
      follow_sphere(move_group, my_plan, joint_model_group, visual_tools);
  }
*/
  
  return 0;
}