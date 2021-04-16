/*
Fixed Unity Publisher to allow to have more than one Robot controlled via one ROSConnector Object
*/

using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    //[RequireComponent(typeof(RosConnector))]
    public abstract class FixedUnityPublisher<T> : MonoBehaviour where T : Message
    {
        public string Topic;
        private string publicationId;

        private RosConnector rosConnector;

        protected virtual void Start()
        {
            rosConnector = GameObject.Find("RosConnector").GetComponent<RosConnector>();
            publicationId = rosConnector.RosSocket.Advertise<T>(Topic);
        }

        protected void Publish(T message)
        {
            rosConnector.RosSocket.Publish(publicationId, message);
        }
    }
}