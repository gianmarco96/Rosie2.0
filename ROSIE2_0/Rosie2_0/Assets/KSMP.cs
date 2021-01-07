
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

    public string NetworkMasterIP = "ws://192.168.0.51:9090";
    public KSMPs TypeOfKSMP = KSMPs.ROS;
    public EntityType TypeOfEntity = EntityType.manipulator;
    public string Topic = "joint_states";
    public string ActionName = "move_group";


    private UrdfRobot UrdfRobot;
    private RosConnector RosConnector;
    private JointStatePatcher JointPatcher;
    private JointStateSubscriber JointStateSubscriber;
    private UnityFibonacciActionClient UnityFibonacciActionClient;

    public void Awake()
    {
        UrdfRobot = GetComponents<UrdfRobot>()[0];
        gameObject.AddComponent<Status2Text>();
        switch (TypeOfKSMP)
        {
            case KSMPs.ROS:
                gameObject.AddComponent<RosConnector>();
                RosConnector = GetComponent<RosConnector>();
                RosConnector.RosBridgeServerUrl = NetworkMasterIP;
                switch (TypeOfEntity)
                {
                    case EntityType.manipulator:
                        gameObject.AddComponent<JointStatePatcher>();
                        JointPatcher = gameObject.GetComponent<JointStatePatcher>();
                        JointPatcher.UrdfRobot = UrdfRobot;
                        JointPatcher.SetSubscribeJointStates(true);

                        JointStateSubscriber = gameObject.GetComponent<JointStateSubscriber>();
                        JointStateSubscriber.Topic = Topic;

                        UnityFibonacciActionClient = gameObject.AddComponent<UnityFibonacciActionClient>();
                        UnityFibonacciActionClient.actionName = ActionName;
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

    public void Start()
    {
        
    }

}
