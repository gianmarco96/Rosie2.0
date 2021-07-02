using UnityEngine;

namespace RosSharp.RosBridgeClient.Actionlib
{
    [RequireComponent(typeof(RosConnector))]
    public class UnityMoveItActionClient : MonoBehaviour
    {
        private RosConnector rosConnector;
        public FibonacciActionClient fibonacciActionClient;
        public MoveItActionClient moveItActionClient;

        public string actionName;
        public int fibonacciOrder = 20;
        public string status = "";
        public string feedback = "";
        public string result = "";

        private void Start()
        {
            moveItActionClient = new MoveItActionClient(actionName, rosConnector.RosSocket);
            rosConnector = GetComponent<RosConnector>();
            fibonacciActionClient = new FibonacciActionClient(actionName, rosConnector.RosSocket);
            fibonacciActionClient.Initialize();
        }

        private void Update()
        {
            //status   = fibonacciActionClient.GetStatusString();
            //feedback = fibonacciActionClient.GetFeedbackString();
            //result   = fibonacciActionClient.GetResultString();
        }

        public void RegisterGoal()
        {
            fibonacciActionClient.fibonacciOrder = fibonacciOrder;
        }

    }
}

