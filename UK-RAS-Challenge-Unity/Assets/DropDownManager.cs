using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownManager : MonoBehaviour

{
    private Dropdown dropdown;
    private List<string> DropdownOptions = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        dropdown = gameObject.GetComponent<Dropdown>();
        UpdateOptions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateOptions()
    {

        this.dropdown.ClearOptions();

       GameObject[] robots = GameObject.FindGameObjectsWithTag("robot");
        
        for(int i =0; i < robots.Length; i++)
        {
            DropdownOptions.Add(robots[i].name);
        }
        this.dropdown.AddOptions(DropdownOptions);
    }
}
