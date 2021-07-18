using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class GripperPublisher : FixedUnityPublisher<MessageTypes.Robotiq2fGripperControl.Robotiq2FGripper_robot_output>
    {
        private MessageTypes.Robotiq2fGripperControl.Robotiq2FGripper_robot_output message;
        public byte rpr = 150;
        public GameObject robotGripper;
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Topic = "iiwa/Robotiq2FGripperRobotOutput";
            base.Start();
            InitializeMessage();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            //UpdateMessage();
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Robotiq2fGripperControl.Robotiq2FGripper_robot_output(1, 1, 0, 0, 255, 150);
            //Publish(message);
        }

        public void UpdateMessage()
        {
            message.rPR = rpr;
            Publish(message);
        }

        //public void CloseGripper()
        //{
        //    RaycastHit hit;
        //    if (Physics.Raycast(robotGripper.transform.position, robotGripper.transform.up, out hit))
        //    {
        //        if (hit.transform.gameObject.name == "Sponge") rpr = 100;
        //        //else if (hit.transform.gameObject.name == "AntibacterialGel") rpr = 150;
        //        else rpr = 150;
        //    }
            
        //    UpdateMessage();
        //}
        
        //public void OpenGripper()
        //{
        //    rpr = 0;
        //    UpdateMessage();
        //}

        //public void SqueezeBottle()
        //{
        //    rpr = 160;
        //    UpdateMessage();
        //}
    }

    ///iiwa/Robotiq2FGripperRobotOutput
}
