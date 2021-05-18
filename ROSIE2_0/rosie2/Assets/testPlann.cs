/*
© Siemens AG, 2017-2019
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

using System.Collections.Generic;

namespace RosSharp.RosBridgeClient
{
    public class TestPlann : FixedUnitySubscriber<MessageTypes.Moveit.DisplayTrajectory>
    {
        public List<string> JointNames;
        public List<JointStateWriter> JointStateWriters;

        protected override void ReceiveMessage(MessageTypes.Moveit.DisplayTrajectory message)
        {
            int index;
            for (int i = 0; i < message.trajectory[0].joint_trajectory.points.Length; i++)
            {
                index = JointNames.IndexOf(message.trajectory[0].joint_trajectory.joint_names[i]);
                //if (index != -1)
                    //JointStateWriters[index].Write((float)message.trajectory[0].joint_trajectory.points[i].positions[i];
            }
        }
    }
}

// Create joint_state publisher from display_trajectory 