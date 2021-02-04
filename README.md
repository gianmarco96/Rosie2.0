# Rosie2.0
## ROS installation
Install and setup ROS (melodic recommended) on your Ubuntu Machine or VM. 
<br />
http://wiki.ros.org/melodic/Installation/Ubuntu
<br />
Initialise a catkin workspace and clone this repository 

```
mkdir R2_iiwa_stack_ws && cd R2_iiwa_stack_ws && mkdir src
catkin_init_workspace
git clone https://github.com/gianmarco96/Rosie2.0
cp -r -f Rosie2.0/iiwa_stack/ src
```
Download the dependencies 
```
rosdep install --from-paths src --ignore-src -r -y
```
Build the workspace :
```
catkin build
```
Source the workspace :
```
source devel/setup.bash
```
Test the installation was successful by launching the iiwa demo
```
roslaunch iiwa_moveit demo.launch
```
You can now remove the Rosie2.0 folder from the workspace
```
rm -f -r Rosie2.0
```
We now need to setup the ROS MASTER IP. Open
```
gedit ~/.bashrc &
```
and append these two lines at the end
```
export ROS_IP=xxx.xxx.xxx.xxx
export ROS_MASTER_URI=http://$ROS_IP:11311
```
Replace xxx.xxx.xxx.xxx with your machine IP iddress. In order for you ro control 
the real robot this should be in the same subnet of the iiwa. For the moment however
your current machine IP address will suffice. To get your machine IP address, open 
a new terminal and type
```
hostname -I
```
Save the ~/.bashrc and source it
```
source ~/.bashrc
```
We're almost there. Now we just need to install the rosbridge-server to allow
us to create a bridge between ROS and Unity. Simply type in a terminal
```
sudo apt install ros-melodic-rosbridge-server
```
That's it. now we are ready to launch the application. 
1. First launch the rosbridge server
```
roslaunch rosbridge_server rosbridge_websocket.launch 
```
2. Now launch the gazebo Simulation
```
roslaunch iiwa_moveit moveit_planning_execution.launch model:=iiwa14
```

3. And finally, when your Unity environment is up and running you can run the rosie2 application to interact with Unity
```
roslaunch rosie2_test rosie2_test.launch
```
## Unity Installation
