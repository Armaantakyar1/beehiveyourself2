using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class flowertool : Editor
{
    private bool objectActive = true;
    [SerializeField]GameObject[] Flower;
    private float activationThreshold = 0.1f;
    public override void OnInspectorGUI()
    {
        flowertool script = (flowertool)target;
        activationThreshold = EditorGUILayout.Slider("Activation Threshold", activationThreshold, 0, 1);

        for (int i = 0; i < Flower.Length; i++)
        {
            if (activationThreshold > i / (float)Flower.Length)
            {
                Flower[i].SetActive(true);
            }
            else
            {
                Flower[i].SetActive(false);
            }
        }
    }
}
