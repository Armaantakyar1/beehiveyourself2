using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : MonoBehaviour
{
    ///make a list of direction points
    ///check play's distance from the destination point, once he reaches it, change target to next destination point
    ///repeat cycle when done.
    

    public Transform [] destinationPoints;
    public int index=0;
    [SerializeField] SeekingBehaviour seeker;

    void Start()
    {
        Debug.Log("hi");
        GetComponent<Attacking>().enabled = false;
        GetComponent<Inspecting>().enabled = false;
        GetComponent<SeekingBehaviour>().SetTarget(destinationPoints[0].position);
        Debug.Log("target set to 0");

    }

    void Update()
    {            
        GetComponent<SeekingBehaviour>().SetTarget(destinationPoints[index].position);
        GetComponent<SeekingBehaviour>().Seek();


        if (Vector3.Distance(this.transform.position, destinationPoints[index].position) <= 0.5f)
        {
            GetComponent<Attacking>().chasingTimer = 0;
            Debug.Log("distance idk");
            index++;
            Debug.Log("index is increasing");
            Debug.Log("seeking rn");
            if (index== destinationPoints.Length)
            {
                Debug.Log("length max");
                index = 0;
            }
            Debug.Log("target is set to index");
        }
        Debug.Log("Index:" + index);            

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.enabled = false;
            GetComponent<Inspecting>().enabled = true;

        }
    }
}
