using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class service : MonoBehaviour
{
    // Start is called before the first frame update


    public void OnValidate(bool send)
    {
        if(send == true)
        {
            Debug.Log("true");
        }
        else
        {

        }
        send = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
