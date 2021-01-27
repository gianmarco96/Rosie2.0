# Rosie2.0
Rosie2.0
From the ROS set up the MASTER IP address first. Then run the following commands
roslaunch rosbridge_server rosbridge_websocket.launch # This assumes you have installed the ROS bridge already if not do so
in another terminal 
roslaunch iiwa_moveit moveit_planning_execution.launch model:=iiwa14
And finally in another terminal 
roslaunch rosie2_test rosie2_test
#!/usr/bin/env python

import copy
import sys
from math import pi

import geometry_msgs.msg
import moveit_msgs.msg
import rospy
from std_msgs.msg import String

import moveit_commander
from moveit_commander.conversions import pose_to_list

## END_SUB_TUTORIAL


def go_to_joint_state(group):

    joint_goal = group.get_current_joint_values()
    joint_goal[0] = 0
    joint_goal[1] = -pi / 4
    joint_goal[2] = 0
    joint_goal[3] = -pi / 2
    joint_goal[4] = 0
    joint_goal[5] = pi / 3
    joint_goal[6] = 0

    group.go(joint_goal, wait=True)

    # Calling ``stop()`` ensures that there is no residual movement
    group.stop()


def go_to_pose_goal(self):
    group = self.group

    pose_goal = geometry_msgs.msg.Pose()
    pose_goal.orientation.w = 1.0
    pose_goal.position.x = 0.4
    pose_goal.position.y = 0.1
    pose_goal.position.z = 0.4
    group.set_pose_target(pose_goal)

    plan = group.go(wait=True)
    # Calling `stop()` ensures that there is no residual movement
    group.stop()

    group.clear_pose_targets()


def plan_cartesian_path(self, scale=1):

    group = self.group

    waypoints = []

    wpose = group.get_current_pose().pose
    wpose.position.z -= scale * 0.1  # First move up (z)
    wpose.position.y += scale * 0.2  # and sideways (y)
    waypoints.append(copy.deepcopy(wpose))

    wpose.position.x += scale * 0.1  # Second move forward/backwards in (x)
    waypoints.append(copy.deepcopy(wpose))

    wpose.position.y -= scale * 0.1  # Third move sideways (y)
    waypoints.append(copy.deepcopy(wpose))

    (plan, fraction) = group.compute_cartesian_path(
        waypoints, 0.01, 0.0  # waypoints to follow  # eef_step
    )  # jump_threshold

    return plan, fraction


def main():
    moveit_commander.roscpp_initialize(sys.argv)
    rospy.init_node("move_group_python_interface_tutorial", anonymous=True)

    robot = moveit_commander.RobotCommander()

    scene = moveit_commander.PlanningSceneInterface()

    group_name = "manipulator"
    group = moveit_commander.MoveGroupCommander(group_name)

    print "============ Printing robot state"
    print robot.get_current_state()
    print ""


if __name__ == "__main__":
    main()
