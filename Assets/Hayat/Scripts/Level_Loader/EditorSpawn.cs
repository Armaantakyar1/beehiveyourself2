using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorSpawn : EditorWindow
{
    string name = "";
    GameObject prefabToSpawn;
    int radius;

    [MenuItem("Hayat's stuff/Hayat's Tools")]
    public static void ShowWindow()
    {
        GetWindow(typeof(EditorSpawn));
    }
    private void OnGUI()
    {
        name = EditorGUILayout.TextField("Object name", name);
        radius = EditorGUILayout.IntField("Radius", radius);
        prefabToSpawn = EditorGUILayout.ObjectField("Prefab To Spawn", prefabToSpawn, typeof(GameObject), false) as GameObject;
        if(GUILayout.Button("this Button!!!!!!!!!!!!!!!"))
        {
            Spawn();
        }
    }

    void Spawn()
    {
        Vector3 pos = Random.insideUnitCircle * 5;
        GameObject obj =  Instantiate(prefabToSpawn, pos, Quaternion.identity);
        obj.name = name;
    }

}
