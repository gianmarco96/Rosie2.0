using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjWithMouse : MonoBehaviour
{
    bool rotating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDrag()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            /*
            float rotX = Input.GetAxis("Mouse X") * 20.0f * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * 20.0f * Mathf.Deg2Rad;

            transform.RotateAround(Vector3.up, -rotX);
            transform.RotateAround(Vector3.right, -rotY);
            */

            if (Input.GetKeyDown(KeyCode.LeftArrow)) transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
            else if (Input.GetKeyDown(KeyCode.RightArrow)) transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
            else if (Input.GetKeyDown(KeyCode.UpArrow)) transform.Rotate(-90.0f, 0.0f, 0.0f, Space.Self);
            else if (Input.GetKeyDown(KeyCode.DownArrow)) transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);



        }
        else
        {
            float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        }
    }
}
