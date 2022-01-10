
using UnityEngine;
using System;
using RosSharp.Urdf;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.Actionlib;

public enum KSMPs
{
    ROS,
    None
}

public enum EntityType
{
    manipulator,
    AGV,
    drone,
    sensor
}

public class KSMP : MonoBehaviour
{

    public string NetworkMasterIP = "ws://192.168.0.67:9090";
    public KSMPs TypeOfKSMP = KSMPs.ROS;
    public EntityType TypeOfEntity = EntityType.manipulator;
    public bool planRobot = false;
    public string Topic = "iiwa/joint_states";
    public string ActionName = "move_group";


    private UrdfRobot UrdfRobot;
    private GameObject TrajectoryHandler;
    private GameObject RosConnectorObj;
    private RosConnector RosConnector;
    private JointStatePatcher JointPatcher;
    private JointStateSubscriber JointStateSubscriber;
    //private UnityFibonacciActionClient UnityFibonacciActionClient;
    

    public void Awake()
    {
        UrdfRobot = GetComponents<UrdfRobot>()[0];
        // gameObject.AddComponent<Status2Text>();
        switch (TypeOfKSMP)
        {
            case KSMPs.ROS:
                //gameObject.AddComponent<RosConnector>();
                //gameObject.AddComponent<PoseArrayPublisher>();
                // If it does not exist
             /*   if (GameObject.Find("RosConnector") == null)
                {
                    RosConnectorObj = new GameObject("RosConnector");
                }
                else
                    RosConnectorObj = GameObject.Find("RosConnector");
             */

                if (!planRobot) 
                { 
                    //RosConnector = RosConnectorObj.AddComponent<RosConnector>();
                    //gameObject.AddComponent<PoseArrayPublisher>();
                 }
               // RosConnector = RosConnectorObj.GetComponent<RosConnector>();
                //RosConnector.RosBridgeServerUrl = NetworkMasterIP;
                switch (TypeOfEntity)
                {
                    case EntityType.manipulator:
                        gameObject.AddComponent<JointStatePatcher>();
                        JointPatcher = gameObject.GetComponent<JointStatePatcher>();
                        JointPatcher.UrdfRobot = UrdfRobot;
                        JointPatcher.SetSubscribeJointStates(true);
                        if (!planRobot)
                        {
                            JointStateSubscriber = gameObject.GetComponent<JointStateSubscriber>();
                            JointStateSubscriber.Topic = Topic;

                            //gameObject.AddComponent<ExecuteTrajFeedbackSub>();
                        }
                        else
                        {
                            //gameObject.AddComponent<DisplayTrajectorySub>();
                        }
                        
                        /*****************************
                         * Testing: uncomment JointState Subscri and delete DisplatT
                         * ***************************/
                        //gameObject.AddComponent<DisplayTrajectorySub>();

                        break;

                    case EntityType.AGV:
                        // To be implemented
                        break;

                    case EntityType.drone:
                        // To be implemented
                        break;
                    case EntityType.sensor:
                        // To be implemented
                        break;
                    default:
                        // To be implemented
                        break;
                }
                break;

            case KSMPs.None:
                // To be implemented
                break;
            default:
                // To be implemented
                break;
        }

    }

    public void OnValidate()
    {
        if (GameObject.Find("TrajectoryHandler") == null)
        {
            TrajectoryHandler = new GameObject("TrajectoryHandler");
            TrajectoryHandler.AddComponent<CreatePath>();
        }
        else
            TrajectoryHandler = GameObject.Find("TrajectoryHandler");

        if (planRobot)
       
        {
            if (gameObject.GetComponent<DisplayTrajectorySub>() == null)
            {
                gameObject.AddComponent<DisplayTrajectorySub>();
            }
            ;
        }
    }

    

}
