
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


namespace RosSharp.RosBridgeClient
{
    public class PoseArrayPublisher : UnityPublisher<MessageTypes.Geometry.PoseArrayFixed>
    {
        //public Transform PublishedTransform;
        public string FrameId = "world";
        
        

        public MessageTypes.Geometry.PoseArrayFixed message;
        
        private int numberOfPoints;

        private void Awake()
        {
            //message.poses;
            //  message.poses
        }
        protected override void Start()
        {
            base.Topic = "goal_poses";
            base.Start();
            
            
            InitializeMessage();
            

            
        }

        private void FixedUpdate()
        {
            UpdateMessage();
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Geometry.PoseArrayFixed
            {
                header = new MessageTypes.Std.Header()
                {
                    frame_id = FrameId
                },                
            };

        }

        private void UpdateMessage()
        {
            message.header.Update();

            
           
            numberOfPoints = gameObject.GetComponent<CreatePath>().numberOfWaypoints;
            message.poses.Clear();
            for (int i = 0; i < numberOfPoints; i++)
            {
                string name = "Sphere_" + i.ToString();
                GameObject spehere = GameObject.Find(name);
                message.poses.Add(new MessageTypes.Geometry.Pose());
             
                message.poses[i].position.x = spehere.transform.position.z;
                message.poses[i].position.y = - spehere.transform.position.x;
                message.poses[i].position.z = spehere.transform.position.y;
                message.poses[i].orientation.w = spehere.transform.rotation.w;
                message.poses[i].orientation.x = spehere.transform.rotation.z;
                message.poses[i].orientation.y =- spehere.transform.rotation.x;
                message.poses[i].orientation.z = spehere.transform.rotation.y;
            }
            //Debug.Log(message.poses.Count);
            Publish(message);
        }

     

    }
}
