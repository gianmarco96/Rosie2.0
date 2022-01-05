
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using rosapi = RosSharp.RosBridgeClient.MessageTypes.Rosapi;

using RosSharp.RosBridgeClient.MessageTypes.Robotiq2fGripperControl;

namespace RosSharp.RosBridgeClient
{
    public class GripperHandler : MonoBehaviour
    {
        //public Transform PublishedTransform;
        private GameObject OpenGripperButton;
        private GameObject CloseGripperButton;
        private RosConnector RosConnector;
        RosSocket rosSocket;
        private MessageTypes.Geometry.PoseArrayFixed poseRequest = new MessageTypes.Geometry.PoseArrayFixed();
        private string uri = "ws://192.168.1.186:9090";
        private bool gripperRequest = false;


        private void Awake()
        {
            OpenGripperButton = GameObject.Find("OpenGripperButton");
            OpenGripperButton.GetComponent<Button>().onClick.AddListener(OnClickOpen);

            CloseGripperButton = GameObject.Find("CloseGripperButton");
            CloseGripperButton.GetComponent<Button>().onClick.AddListener(OnClickClose);
        }


        protected void Start()
        {
            RosConnector = GameObject.FindObjectOfType<RosConnector>();
            uri = RosConnector.RosBridgeServerUrl;
            rosSocket = new RosSocket(new RosBridgeClient.Protocols.WebSocketSharpProtocol(uri));


        }

        void OnClickOpen()
        {
            gripperRequest = true;
            UnityGripperRequest request = new UnityGripperRequest(gripperRequest);
            rosSocket.CallService<UnityGripperRequest, UnityGripperResponse>("iiwa/gripper_unity_server", ServiceCallHandler, request);
        }

        void OnClickClose()
        {
            gripperRequest = false;
            UnityGripperRequest request = new UnityGripperRequest(gripperRequest);
            rosSocket.CallService<UnityGripperRequest, UnityGripperResponse>("iiwa/gripper_unity_server", ServiceCallHandler, request);
        }

        private static void ServiceCallHandler(UnityGripperResponse res)
        {
           Debug.Log(res.gripper_state);
        }
    }
}