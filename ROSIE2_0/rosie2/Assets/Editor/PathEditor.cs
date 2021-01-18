using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CreatePath))]
public class PathEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CreatePath pathEditor = (CreatePath)target;
        if(GUILayout.Button("Create Path"))
        {
            pathEditor.CreateWaypoints(pathEditor.numberOfWaypoints);
           // Debug.Log("Button Pressed");
        }
        
        if (GUILayout.Button("Delete all waypoints"))
        {
            pathEditor.DestroyWaypoints();
            //Debug.Log("Button 2 Pressed");
        }
    }
}
