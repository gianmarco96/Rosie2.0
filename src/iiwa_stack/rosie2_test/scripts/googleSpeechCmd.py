#!/usr/bin/env python
import rospy
import moveit_commander
import moveit_msgs.msg
import geometry_msgs.msg
import sys
from std_msgs.msg import String

go_home = False

def fulfillment_callback(data):
    print(data)
    if(data.data == "home position"):
        go_home = True
        print("Got what I expected")


    
moveit_commander.roscpp_initialize(sys.argv)
rospy.init_node('move_group_python_interface_tutorial',
                anonymous=True)
rospy.Subscriber("/fulfillmentHandler", String, fulfillment_callback)
google_res = rospy.Publisher("/google_response", String, queue_size=True)

#robot = moveit_commander.RobotCommander()

#scene = moveit_commander.PlanningSceneInterface()


group_name = "manipulator"
group = moveit_commander.MoveGroupCommander(group_name)

joint_goal = group.get_current_joint_values()
joint_goal[0] = 0
joint_goal[1] = 0
joint_goal[2] = 0
joint_goal[3] = 0
joint_goal[4] = 0
joint_goal[5] = 0
joint_goal[6] = 0
#group.go(joint_goal, wait=True)

while(not rospy.is_shutdown()):
    #rospy.sleep(.1)
    #print(go_home)
    if go_home== True:
        print(go_home)
        google_res.publish("should b mving")
        group.go(joint_goal, wait=True)
        go_home = False

    #rospy.spin()


