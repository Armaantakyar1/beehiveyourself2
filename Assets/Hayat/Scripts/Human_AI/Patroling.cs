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
    Rigidbody rb;
    [SerializeField] SeekingBehaviour seeker;

    void Start()
    {
        Debug.Log("hi");
        //seeker = GetComponent<SeekingBehaviour>();
        //seeker.SetTarget(destinationPoints[0].position);
        GetComponent<SeekingBehaviour>().SetTarget(destinationPoints[0].position);
        Debug.Log("target set to 0");
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (Vector3.Distance(this.transform.position, destinationPoints[index].position) <= 0.5f)
        {
            Debug.Log("distance idk");
            index++;
            Debug.Log("index is increasing");
            GetComponent<SeekingBehaviour>().Seek(rb.velocity);
            Debug.Log("seeking rn");
            if (index== destinationPoints.Length)
            {
                Debug.Log("length max");
                index = 0;
            }
            GetComponent<SeekingBehaviour>().SetTarget(destinationPoints[index].position);
            Debug.Log("target is set to index");
        }
        Debug.Log("Index:" + index);            

    }
   
    
}
