using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSelection : MonoBehaviour
{
    public GameObject selectedSphere;
    public Material sphereMaterial;
    public Material selectedSphereMaterial;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Respawn")
                {
                    if (selectedSphere != null) selectedSphere.GetComponent<MeshRenderer>().material = sphereMaterial; // reset before selecting new
                    selectedSphere = hit.transform.gameObject;
                    selectedSphere.GetComponent<MeshRenderer>().material = selectedSphereMaterial;
                }
                else
                {
                    if (selectedSphere != null) selectedSphere.GetComponent<MeshRenderer>().material = sphereMaterial;
                    selectedSphere = null;

                }
            }
            else
            {
                if (selectedSphere != null) selectedSphere.GetComponent<MeshRenderer>().material = sphereMaterial;
                selectedSphere = null; // repeated as there is no raycast for background
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            selectedSphere.GetComponent<MeshRenderer>().material = sphereMaterial;
            selectedSphere = null;
        }



        if (selectedSphere != null)
        {



            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                /*
                float rotX = Input.GetAxis("Mouse X") * 20.0f * Mathf.Deg2Rad;
                float rotY = Input.GetAxis("Mouse Y") * 20.0f * Mathf.Deg2Rad;
                transform.RotateAround(Vector3.up, -rotX);
                transform.RotateAround(Vector3.right, -rotY);
                */

                if (Input.GetKeyDown(KeyCode.LeftArrow)) selectedSphere.transform.Rotate(0.0f, -90.0f, 0.0f, Space.World);
                else if (Input.GetKeyDown(KeyCode.RightArrow)) selectedSphere.transform.Rotate(0.0f, 90.0f, 0.0f, Space.World);
                else if (Input.GetKeyDown(KeyCode.UpArrow)) selectedSphere.transform.Rotate(-90.0f, 0.0f, 0.0f, Space.World);
                else if (Input.GetKeyDown(KeyCode.DownArrow)) selectedSphere.transform.Rotate(90.0f, 0.0f, 0.0f, Space.World);
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    if (Input.GetKey(KeyCode.LeftArrow)) selectedSphere.transform.Translate(0.5f * Time.deltaTime, 0.0f, 0.0f, Space.World);
                    else if (Input.GetKey(KeyCode.RightArrow)) selectedSphere.transform.Translate(-0.5f * Time.deltaTime, 0.0f, 0.0f, Space.World);
                    if (Input.GetKey(KeyCode.UpArrow)) selectedSphere.transform.Translate(0.0f, 0.0f, -0.5f * Time.deltaTime, Space.World);
                    else if (Input.GetKey(KeyCode.DownArrow)) selectedSphere.transform.Translate(0.0f, 0.0f, 0.5f * Time.deltaTime, Space.World);
                    if (Input.GetKey(KeyCode.W)) selectedSphere.transform.Translate(0.0f, 0.5f * Time.deltaTime, 0.0f, Space.World);
                    else if (Input.GetKey(KeyCode.S)) selectedSphere.transform.Translate(0.0f, -0.5f * Time.deltaTime, 0.0f, Space.World);
                }
                else
                {
                    if (Input.GetKey(KeyCode.LeftArrow)) selectedSphere.transform.Translate(0.1f * Time.deltaTime, 0.0f, 0.0f, Space.World);
                    else if (Input.GetKey(KeyCode.RightArrow)) selectedSphere.transform.Translate(-0.1f * Time.deltaTime, 0.0f, 0.0f, Space.World);
                    if (Input.GetKey(KeyCode.UpArrow)) selectedSphere.transform.Translate(0.0f, 0.0f, -0.1f * Time.deltaTime, Space.World);
                    else if (Input.GetKey(KeyCode.DownArrow)) selectedSphere.transform.Translate(0.0f, 0.0f, 0.1f * Time.deltaTime, Space.World);
                    if (Input.GetKey(KeyCode.W)) selectedSphere.transform.Translate(0.0f, 0.1f * Time.deltaTime, 0.0f, Space.World);
                    else if (Input.GetKey(KeyCode.S)) selectedSphere.transform.Translate(0.0f, -0.1f * Time.deltaTime, 0.0f, Space.World);
                }

            }

            /*else
            {
                float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
            }*/
        }
    }
}
