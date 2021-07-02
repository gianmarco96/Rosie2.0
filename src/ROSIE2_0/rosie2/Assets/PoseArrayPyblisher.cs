
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


namespace RosSharp.RosBridgeClient
{
    public class PoseArrayPublisher : FixedUnityPublisher<MessageTypes.Geometry.PoseArrayFixed>
    {
        //public Transform PublishedTransform;
        public string FrameId = "world";
        private GameObject button; 



        public MessageTypes.Geometry.PoseArrayFixed message;

        private CreatePath createPath;
        private int numberOfPoints;

        private void Awake()
        {
            //message.poses;
            //  message.poses
            button = GameObject.Find("Button");
            button.GetComponent<Button>().onClick.AddListener(OnClick);

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
            //message.header.Update();

            
           
            createPath = gameObject.GetComponent<CreatePath>();
            numberOfPoints = createPath.numberOfWaypoints;
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
            
        }

        void OnClick()
        {
            Debug.Log("Send Goal");
            Publish(message);
        }
        
    }
}
