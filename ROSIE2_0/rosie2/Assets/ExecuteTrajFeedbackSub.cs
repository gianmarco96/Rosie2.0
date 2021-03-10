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
using UnityEngine.UI;

namespace RosSharp.RosBridgeClient
{
    public class ExecuteTrajFeedbackSub : UnitySubscriber<MessageTypes.Moveit.ExecuteTrajectoryActionFeedback>
    {
        public string status = "Pending";
        private GameObject MoveitStatText;
        private bool isMessageReceived;
        
       
        protected override void Start()
        {
            base.Topic = "iiwa/execute_trajectory/feedback";
            base.Start();
            MoveitStatText = GameObject.Find("MoveItStatsText");
            MoveitStatText.GetComponent<Text>().text = status;
                        
        }

        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        protected override void ReceiveMessage(MessageTypes.Moveit.ExecuteTrajectoryActionFeedback message)
        {
           
            Debug.Log("Planning request computed");
            status = message.status.text;
            isMessageReceived = true;
            
        }

        private void ProcessMessage()
        {
            MoveitStatText.GetComponent<Text>().text = status;

        }

        

        
    }
}