﻿/*
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
using System.Collections;
using System;

namespace RosSharp.RosBridgeClient
{
    public class DisplayTrajectorySub : FixedUnitySubscriber<MessageTypes.Moveit.DisplayTrajectory>
    {
        private bool isMessageReceived = false;
        private bool readyToshow;
        private MessageTypes.Moveit.DisplayTrajectory plannedTrajectory;
        private int point_counter = 0;
        public string planned_path_topic = "iiwa/move_group/display_planned_path";
        public string robotName;
        public int numberOfJoints;
        // need to generalise to case of joints > or < 7
        private List <JointStateWriter> JointStateWriterList = new List<JointStateWriter>();

        /*****************************************************************
         *                              TEST
         * ****************************************************************/
        private double timeRemaining = 0;
        private bool timerIsRunning = false;


        /*****************************************************************
         *                              END
         * ****************************************************************/
        private float timer = 0;

        protected override void Start()
        {

            timerIsRunning = true;
            robotName = gameObject.name;


            base.Topic = planned_path_topic;
            base.Start();
            //for (int i = 0; i < numberOfJoints; i++ )
            //{
            //    int n = i + 1;
            //    JointStateWriterList = GameObject.Find("t_iiwa_link_"+n.ToString()).GetComponent<JointStateWriter>();
            //}
            //Debug.Log(generateJointStateWrites(robotName)[0].name);

    }

        private void Update()
        {
            if (isMessageReceived)
            {

                if (timerIsRunning)
                {
                    if (timeRemaining > 0)
                    {
                        timeRemaining -= Time.deltaTime;
                    }
                    else
                    {
                        //Debug.Log("Time: " + timeRemaining);
                        
                        timeRemaining = 0;
                        timerIsRunning = false;
                        ProcessMessage();
                    }
                }
                //Debug.Log(GameObject.Find("iiwa_link_" + 1.ToString()).GetComponent<JointStateWriter>());
            }
        }
        protected override void ReceiveMessage(MessageTypes.Moveit.DisplayTrajectory message)
        {
            plannedTrajectory = message;
            isMessageReceived = true;
            
            //timeRemaining = 5;
            //timerIsRunning = true;



        }

        private void ProcessMessage()
        {
            int n_joints = plannedTrajectory.trajectory[0].joint_trajectory.points[0].positions.Length;
            int n_points = plannedTrajectory.trajectory[0].joint_trajectory.points.Length;
            JointStateWriter[] JointStateWriter = new JointStateWriter[7];

            JointStateWriter = generateJointStateWrites( robotName);

            //for (int j = 0; j < n_points; j++)
            //{
            if (plannedTrajectory.trajectory[0].joint_trajectory.joint_names.Length > 1) 
            {
                for (int i = 0; i < n_joints; i++)
                {
                    JointStateWriter[i].Write((float)plannedTrajectory.trajectory[0].joint_trajectory.points[point_counter].positions[i]);

                }

            }
            
            //}


            //timeRemaining = plannedTrajectory.trajectory[0].joint_trajectory.points[point_counter].time_from_start.secs
            //    + plannedTrajectory.trajectory[0].joint_trajectory.points[point_counter].time_from_start.nsecs * Math.Pow(10,-9);
            timeRemaining = 0.05;
            timerIsRunning = true;
            point_counter += 1;
            if (point_counter == n_points)
            {
                point_counter = 0;
                timeRemaining = 0;
                isMessageReceived = false;
            }

        }

        private JointStateWriter[] generateJointStateWrites(string robotName)
        {
            GameObject robot = GameObject.Find(robotName);
            //Debug.Log(robot);
            int jointSize = robot.GetComponentsInChildren<JointStateWriter>().Length;


            for (int i =0; i < jointSize; i++)
            {
                JointStateWriterList.Add(robot.GetComponentsInChildren<JointStateWriter>()[i]);
            }
            return JointStateWriterList.ToArray();
        }



    }
}