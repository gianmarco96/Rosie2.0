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
    public class TrajectorySub : FixedUnitySubscriber<MessageTypes.Moveit.RobotTrajectory>
    {
        public string traj_stats;
        private MessageTypes.Moveit.RobotTrajectory trajectory;
        private bool isMessageReceived;

        protected override void Start()
        {
            base.Topic = "/iiwa/unity_traj";
            base.Start();
        }

        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        protected override void ReceiveMessage(MessageTypes.Moveit.RobotTrajectory message)
        {
            trajectory = message;
            isMessageReceived = true;
            Debug.Log("Received traj");
        }

        private void ProcessMessage()
        {
            traj_stats = "MoveIt generated " + trajectory.joint_trajectory.points.Length + " waypoints";
            gameObject.GetComponent<ExecuteTrajFeedbackSub>().status = gameObject.GetComponent<ExecuteTrajFeedbackSub>().status
                + "\n\n" + traj_stats;
            isMessageReceived = false;
        }

       
    }
}