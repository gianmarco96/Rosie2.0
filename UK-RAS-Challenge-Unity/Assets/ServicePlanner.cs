
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using rosapi = RosSharp.RosBridgeClient.MessageTypes.Rosapi;
using TMPro;

using RosSharp.RosBridgeClient.MessageTypes.Rosie2Test;

namespace RosSharp.RosBridgeClient
{
    public class ServicePlanner : MonoBehaviour
    {
        //public Transform PublishedTransform;
        public string FrameId = "world"; // do I need to specify this?
        public string test = "test";
        
        private GameObject planButton;
        private GameObject executeButton;
        private RosConnector RosConnector;

        GameObject MoveitStatText ;

        private string feedback;
        private RosSocket rosSocket;
        private CreatePath createPath;
        private int numberOfPoints = 0;
        private MessageTypes.Geometry.PoseArrayFixed poseRequest = new MessageTypes.Geometry.PoseArrayFixed();
        private string uri = "ws://192.168.1.186:9090";

        
        private void Awake()
        {

            

            planButton = GameObject.Find("PlanGoalButton");
            planButton.GetComponent<Button>().onClick.AddListener(OnClickPlan);

            executeButton = GameObject.Find("SendGoalButton");
            executeButton.GetComponent<Button>().onClick.AddListener(OnClickExecute);
        }


        protected void Start()
        {
            RosConnector = GameObject.FindObjectOfType<RosConnector>();
            uri = RosConnector.RosBridgeServerUrl;
            rosSocket = new RosSocket(new RosBridgeClient.Protocols.WebSocketSharpProtocol(uri));

            createPath = gameObject.GetComponent<CreatePath>();
            numberOfPoints = createPath.numberOfWaypoints;
            MoveitStatText = GameObject.Find("MoveItStatsText");
            MoveitStatText.GetComponent<TMP_Text>().text = "suuuca";



        }

        private void FixedUpdate()
        {
            //UpdateMessage();
            
        }

        private void UpdateMessage()
        {
            createPath = gameObject.GetComponent<CreatePath>();
            numberOfPoints = createPath.numberOfWaypoints;
            poseRequest.poses.Clear();
            for (int i = 0; i < numberOfPoints; i++)
            {
                string name = "Sphere_" + i.ToString();
                GameObject spehere = GameObject.Find(name);
                poseRequest.poses.Add(new MessageTypes.Geometry.Pose());

                poseRequest.poses[i].position.x = spehere.transform.position.z;
                poseRequest.poses[i].position.y = -spehere.transform.position.x;
                poseRequest.poses[i].position.z = spehere.transform.position.y;
                poseRequest.poses[i].orientation.w = spehere.transform.rotation.w;
                poseRequest.poses[i].orientation.x = spehere.transform.rotation.z;
                poseRequest.poses[i].orientation.y = -spehere.transform.rotation.x;
                poseRequest.poses[i].orientation.z = spehere.transform.rotation.y;
            }

        }

        void OnClickPlan()
        {
            UpdateMessage();


            PlanSrvRequest request = new PlanSrvRequest(poseRequest, true);
            //Call service request
            rosSocket.CallService<PlanSrvRequest, PlanSrvResponse>("iiwa/planService", ServiceCallHandler, request);
        }

        void OnClickExecute()
        {
            UpdateMessage();
            PlanSrvRequest request = new PlanSrvRequest(poseRequest, false);
            //Call service request
            rosSocket.CallService<PlanSrvRequest, PlanSrvResponse>("iiwa/planService", ServiceCallHandler, request);
        }
        private void updateMessage( string feedback)
        {
            MoveitStatText.GetComponent<TMP_Text>().text = feedback; 

        }
        private void ServiceCallHandler(PlanSrvResponse res)
        {
            Debug.Log(res.feedback.data);

            test = res.feedback.data;



        }
    }
}