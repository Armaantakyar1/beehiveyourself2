using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : MonoBehaviour
{
    ///make a list of direction points
    ///check if player is collidng with previous point, and next point is not null, move to another point.
    ///repeat cycle when done.


    [SerializeField] Transform [] destinationPoints;
    [SerializeField] int index=0;
    Rigidbody rb;

    void Start()
    {
        GetComponent<SeekingBehaviour>().SetTarget(destinationPoints[0].position);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Vector3.Distance(this.transform.position, destinationPoints[index].position) <= 0.5f)
        {       
            index++;
            GetComponent<SeekingBehaviour>().Seek(rb.velocity);

            if (index== destinationPoints.Length)
            {
                index = 0;
            }
            GetComponent<SeekingBehaviour>().SetTarget(destinationPoints[index].position);
        }
        Debug.Log(index);            

    }


    
}
