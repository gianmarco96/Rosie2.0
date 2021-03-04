using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePath : MonoBehaviour
{
    public int numberOfWaypoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateWaypoints(int numberOfWaypoints)
    {
        int oldNumberOfWaypoints = FindSpheres().Length;
        int newNumberOfWaypoints = numberOfWaypoints- oldNumberOfWaypoints;
        if (numberOfWaypoints > oldNumberOfWaypoints)
        {
            //Debug.Log("I'm here!");
            int counter = oldNumberOfWaypoints;
            for (int i = 0; i < newNumberOfWaypoints; i++)
            {
                
                string name = "Sphere_" + counter.ToString();
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.name = name;
                sphere.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                sphere.transform.position = new Vector3(-((i + 1) / 10.0f), 2.0f, 0f);
                //Debug.Log(counter);
                sphere.gameObject.tag = "Respawn";
                counter++;
            }
            
        }
        else
        {
            Debug.Log("There are already " + oldNumberOfWaypoints.ToString() + " Waypoints!");
        }

    }

    public void DestroyWaypoints()
    {

        GameObject[] Spheres = FindSpheres();
        foreach (GameObject sphere in Spheres)
        {
            DestroyImmediate(sphere);
        }
    }

    public GameObject[] FindSpheres()
    {
        GameObject[] Spheres = GameObject.FindGameObjectsWithTag("Respawn");
        return Spheres;
    }
}
