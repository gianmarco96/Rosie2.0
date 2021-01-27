# Rosie2.0
Rosie2.0
From the ROS set up the MASTER IP address first. Then run the following commands
roslaunch rosbridge_server rosbridge_websocket.launch # This assumes you have installed the ROS bridge already if not do so
in another terminal 
roslaunch iiwa_moveit moveit_planning_execution.launch model:=iiwa14
And finally in another terminal 
roslaunch rosie2_test rosie2_test
