using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspecting : MonoBehaviour
{
    [SerializeField] Transform bee;
    [SerializeField] float inspectingTimer;
    [SerializeField] float maxTime;

    void OnEnable()
    {
        GetComponent<Patroling>().enabled = false;
        GetComponent<Attacking>().enabled = false;
        GetComponent<SeekingBehaviour>().enabled=false;
        GetComponent<Rigidbody>().velocity=Vector3.zero;
        transform.LookAt(bee);

    }

    void OnDisable()
    {
        GetComponent<SeekingBehaviour>().enabled = true;

    }


    void Update()
    {
        inspectingTimer += Time.deltaTime;
        if (inspectingTimer>= maxTime)
        {
            this.enabled = false;
            GetComponent<Attacking>().enabled = true;

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.enabled = false;
            inspectingTimer = 0;
            GetComponent<Patroling>().enabled = true;

        }
    }
}
