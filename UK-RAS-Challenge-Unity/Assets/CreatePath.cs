using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using RosSharp.RosBridgeClient;
using UnityEngine.UI;

public class CreatePath : MonoBehaviour
{
    public int numberOfWaypoints=0; // unused with hololens
    private GameObject deleteWaypointsButton;
    private GameObject createPathButton;
    private GameObject addWaypointButton;
    private GameObject deleteWaypointButton;
    private PoseArrayPublisher poseArrayPublisher;
    private int requestedNumberOfWaypoints = 0;
    public GameObject spherePrefab;
    public Material sphereMaterial;

    void Awake()
    {
        addWaypointButton = GameObject.Find("AddWaypointButton");
        addWaypointButton.GetComponent<Button>().onClick.AddListener(AddWaypoint);

        deleteWaypointButton = GameObject.Find("DeleteWaypointButton");
        deleteWaypointButton.GetComponent<Button>().onClick.AddListener(DeleteWaypoint);
    }

    void Start()
    {
        GameObject[] Spheres = FindSpheres();
        foreach (GameObject sphere in Spheres)
        {
            requestedNumberOfWaypoints++;
        }
        //Debug.Log("Requested number of waypoints: " + requestedNumberOfWaypoints);
    }

    void Update()
    {
        numberOfWaypoints = requestedNumberOfWaypoints;
    }

    public void AddWaypoint()
    {
        requestedNumberOfWaypoints++;// = requestedNumberOfWaypoints;
        //Debug.Log("Requested number of waypoints after adding: " + requestedNumberOfWaypoints);
        CreateWaypoints(requestedNumberOfWaypoints);
    }

    public void DeleteWaypoint()
    {
        if (requestedNumberOfWaypoints > 0) requestedNumberOfWaypoints--;
        // poseArrayPublisher = gameObject.GetComponent<PoseArrayPublisher>();
        // poseArrayPublisher.ChangeNumberOfPoints(requestedNumberOfWaypoints);

        GameObject[] Spheres = FindSpheres();
        foreach (GameObject sphere in Spheres)
        {
            //Debug.Log(sphere.name);
            string name = sphere.name;
            string[] nameSplit = sphere.name.Split('_');
            int num = Int32.Parse(nameSplit[1]);
            //Debug.Log(num);
            if (num == requestedNumberOfWaypoints)
            {
                //Debug.Log("Deleting");
                DestroyImmediate(sphere);
            }
        }
        //EmptyEventSystem();
    }

    public void CreateWaypoints(int numberOfWaypoints)
    {
        //Debug.Log("Creating " + numberOfWaypoints + " waypoints");
        int oldNumberOfWaypoints = FindSpheres().Length;
        //int newNumberOfWaypoints = numberOfWaypoints- oldNumberOfWaypoints;

        //Debug.Log("Old number of waypoints: " + oldNumberOfWaypoints);
        //Debug.Log("Number of new waypoints: " + (numberOfWaypoints - oldNumberOfWaypoints));

        if (numberOfWaypoints > oldNumberOfWaypoints)
        {
            //Debug.Log("I'm here!");
            int counter = oldNumberOfWaypoints;
            for (int i = oldNumberOfWaypoints; i < numberOfWaypoints; i++)
            {
                //Debug.Log("Creating new waypoint");
                string name = "Sphere_" +  i.ToString();
                //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                GameObject sphere = Instantiate(spherePrefab, new Vector3(0, 0, 0), Quaternion.identity);
                sphere.GetComponent<MeshRenderer>().material = sphereMaterial;
                GameObject sphereParent = GameObject.Find("WaypointCollection");
                sphere.transform.SetParent(sphereParent.GetComponent<Transform>());
                sphere.name = name;
                sphere.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                sphere.transform.localPosition = new Vector3(-((i + 5) / 10.0f), 2.0f, 0f);
                sphere.transform.localRotation = Quaternion.Euler(0, 0, 0);
                sphere.gameObject.tag = "Respawn";

                counter++;
            }
        }
        else
        {
            Debug.LogWarning("There are already " + oldNumberOfWaypoints.ToString() + " Waypoints!");
        }

        //EmptyEventSystem();
    }

    /* Old Function
    public void CreateWaypoints(int numberOfWaypoints)
    {
        Debug.Log("Creating " + numberOfWaypoints + " waypoints");
        int oldNumberOfWaypoints = FindSpheres().Length;
        int newNumberOfWaypoints = numberOfWaypoints- oldNumberOfWaypoints;
        if (numberOfWaypoints > oldNumberOfWaypoints)
        {
            //Debug.Log("I'm here!");
            int counter = oldNumberOfWaypoints;
            for (int i = 0; i < newNumberOfWaypoints; i++)
            {
                Debug.Log("Creating new waypoint");
                string name = "Sphere_" + counter.ToString();
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.name = name;
                sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                sphere.transform.position = new Vector3(-((i + 1) / 10.0f), 2.0f, 0f);
                //Debug.Log(counter);
                sphere.gameObject.tag = "Respawn";
                sphere.AddComponent<MoveObjWithMouse>();
                sphere.AddComponent<ObjectManipulator>();
                sphere.AddComponent<NearInteractionGrabbable>();
                counter++;
            }
            
        }
        else
        {
            Debug.Log("There are already " + oldNumberOfWaypoints.ToString() + " Waypoints!");
        }

    }
     */

    public void DestroyWaypoints()
    {
        GameObject[] Spheres = FindSpheres();
        foreach (GameObject sphere in Spheres)
        {
            DestroyImmediate(sphere);
        }

        //EmptyEventSystem();
    }

    public GameObject[] FindSpheres()
    {
        GameObject[] Spheres = GameObject.FindGameObjectsWithTag("Respawn");
        return Spheres;
    }

    public int GetNumberOfWaypoints()
    {
        return requestedNumberOfWaypoints;
    }

    //    private void EmptyEventSystem()
    //    {
    //        GameObject eventSystemObject = GameObject.Find("EventSystem");
    //        eventSystemObject.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    //    }
}
