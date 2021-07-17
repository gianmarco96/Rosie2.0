using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject target;
    private WaypointSelection waypointSelection;
    //public GameObject cam;
    float camSpeed = 25.0f;
    // Start is called before the first frame update
    void Start()
    {
        waypointSelection = GameObject.FindObjectOfType(typeof(WaypointSelection)) as WaypointSelection;
        transform.LookAt(target.transform.position);

    }


    // Update is called once per frame
    void Update()
    {//(Camera.main.transform.rotation.x > 5.0f)
        if (Input.GetKey("down") && waypointSelection.selectedSphere == null && Camera.main.transform.eulerAngles.x > 1.0f)
        {
            transform.RotateAround(target.transform.position, Vector3.right, camSpeed * Time.deltaTime);
            Debug.Log(Camera.main.transform.eulerAngles.x);
        }
        else if (Input.GetKey("up") && waypointSelection.selectedSphere == null && Camera.main.transform.eulerAngles.x < 89.0f)
        {
            transform.RotateAround(target.transform.position, Vector3.left, camSpeed * Time.deltaTime);
        }

        if (Input.GetKey("space")) // for checking the rotation point
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)) Debug.Log(hit.point);
        }
    }
}
