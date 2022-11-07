using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bee : MonoBehaviour
{
    [SerializeField] GameObject beeHive;
    [SerializeField] Timers timerScript;

    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == beeHive)
        {
            timerScript.inBeehive = true;
            Debug.Log("bees are in the beehive");
        }
    }
    private void Update()
    {
        
    }
}