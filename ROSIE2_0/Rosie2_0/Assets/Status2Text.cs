using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status2Text : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject Texttest = new GameObject("Texttest", typeof(RectTransform));
        Texttest.transform.SetParent(this.transform);
        Texttest.AddComponent<CanvasRenderer>(); 
        Text t = Texttest.AddComponent<Text>();
        
        t.text = "wee";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
