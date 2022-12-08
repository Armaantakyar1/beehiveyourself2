using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bee : MonoBehaviour
{
    [SerializeField] GameObject beeHive;
    [SerializeField] Timers timerScript;
    [SerializeField] HumanWandering human;

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
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Reset"))
        {
            human.isInspecting = false;
            human.timerBeforeAttacking = human.maxTimerBeforeAttacking;
        }
    }
    private void Update()
    {
        
    }
}