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
using System.Collections.Generic;
using RosSharp.RosBridgeClient.MessageTypes.Trajectory;

namespace RosSharp.RosBridgeClient
{
    public class MoveGroupResultSub : UnitySubscriber<MessageTypes.Moveit.MoveGroupActionResult>
    {
        
        public string status = "Pending";

        private MessageTypes.Trajectory.JointTrajectory traj;
        private bool isMessageReceived;

       
        protected override void Start()
        {
            base.Start();
            base.Topic = "iiwa/move_group/result";
        }

        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        protected override void ReceiveMessage(MessageTypes.Moveit.MoveGroupActionResult message)
        {
           
            Debug.Log("Planning request computed");
            status = message.status.text;
            traj = GetTrajectory(message);
            
            isMessageReceived = true;
            ProcessMessage();
        }

        private void ProcessMessage()
        {
            //Debug.Log(traj.points[0].positions[0]);
        }

        private MessageTypes.Trajectory.JointTrajectory GetTrajectory(MessageTypes.Moveit.MoveGroupActionResult message)
        {
            return new MessageTypes.Trajectory.JointTrajectory(
                message.header,
                message.result.trajectory_start.joint_state.name,
                message.result.planned_trajectory.joint_trajectory.points);
        }

        
    }
}