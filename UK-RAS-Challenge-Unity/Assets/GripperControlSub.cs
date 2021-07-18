/*
© Siemens AG, 2017-2018
Author: Dr. Martin Bischoff (martin.bischoff@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class GripperControlSub : FixedUnitySubscriber<MessageTypes.Robotiq2fGripperControl.Robotiq2FGripper_robot_output>
    {
        public MessageTypes.Robotiq2fGripperControl.Robotiq2FGripper_robot_output gripper_Robot_Output;
        private GripperControl gripperControl;
        public bool isMessageReceived;

        protected override void Start()
        {
            base.Start();
            base.Topic = "iiwa/Robotiq2FGripperRobotOutput";
            gripperControl = gameObject.GetComponent<GripperControl>();
        }

        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();

        }

        protected override void ReceiveMessage(MessageTypes.Robotiq2fGripperControl.Robotiq2FGripper_robot_output message)
        {
            gripper_Robot_Output = message;
            
            isMessageReceived = true;

        }

        private void ProcessMessage()
        {
            if(gripper_Robot_Output.rPR == 0)
            {
                gripperControl.OpenGripper();
            }
            if (gripper_Robot_Output.rPR == 150)
            {
                gripperControl.CloseGripper();
            }
            if (gripper_Robot_Output.rPR == 155)
            {
                gripperControl.SqueezeBottle();
            }
        }

        //private Vector3 GetPosition(MessageTypes.Geometry.PoseStamped message)
        //{
        //    return new Vector3(
        //        (float)message.pose.position.x,
        //        (float)message.pose.position.y,
        //        (float)message.pose.position.z);
        //}

        //private Quaternion GetRotation(MessageTypes.Geometry.PoseStamped message)
        //{
        //    return new Quaternion(
        //        (float)message.pose.orientation.x,
        //        (float)message.pose.orientation.y,
        //        (float)message.pose.orientation.z,
        //        (float)message.pose.orientation.w);
        //}
    }
}