using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering_2 : MonoBehaviour
{
    //make a list of direction points
    //check if player is collidng with previous point, and next point is not null, move to another point.
    //repeat cycle when done.
    [SerializeField] List<GameObject> destinationPoints = new List<GameObject>();
    [SerializeField] Vector3 currentPositionPoint;
    Vector3 targetPoint;
    [SerializeField] float speed;
    Rigidbody rb;

    void Start()
    {
        currentPositionPoint = destinationPoints[0].transform.position;
        //GameObject prevPoint = destinationPoints[i - 1];
        rb = GetComponent<Rigidbody>();
        Debug.Log(targetPoint);
    }

    private void OnTriggerEnter(Collider other)
    {
        int i = 0;
        GameObject nextPoint = destinationPoints[i + 1];
        targetPoint = nextPoint.transform.position;
        Debug.Log(nextPoint);
        if (other.CompareTag("Movement points"))
        {
            if (nextPoint!= null)
            {
                GoingToTarget();
                //move to destination point
            }
        }
    }

    void GoingToTarget()
    {
        var direction = (targetPoint - transform.position);
        var distance = Vector3.Distance(targetPoint, transform.position);
        rb.velocity += direction * speed;
        transform.LookAt(targetPoint);

        if (distance<=0)
        {
            rb.velocity = Vector3.zero;
        }

    }
    void Update()
    {
        
    }
}
