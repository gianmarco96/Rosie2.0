/*
Fixed Unity subscriber by Gianmarco Pisanelli. This will allow to have more than one robot in the scene and control them via a ROSConnector Object
*/

using System.Threading;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    //[RequireComponent(typeof(RosConnector))]
    public abstract class FixedUnitySubscriber<T> : MonoBehaviour where T : Message
    {
        public string Topic;
        public float TimeStep;

        private RosConnector rosConnector;
        private readonly int SecondsTimeout = 1;

        protected virtual void Start()
        {
            rosConnector = GameObject.Find("RosConnector").GetComponent<RosConnector>();
            new Thread(Subscribe).Start();
        }

        private void Subscribe()
        {

            if (!rosConnector.IsConnected.WaitOne(SecondsTimeout * 1000))
                Debug.LogWarning("Failed to subscribe: RosConnector not connected");

            rosConnector.RosSocket.Subscribe<T>(Topic, ReceiveMessage, (int)(TimeStep * 1000)); // the rate(in ms in between messages) at which to throttle the topics
        }

        protected abstract void ReceiveMessage(T message);

    }
}