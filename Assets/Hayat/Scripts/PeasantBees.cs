using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantBees : MonoBehaviour
{

    [SerializeField] Transform target1;
    public Transform flowerTarget ;
    Vector3 direction;
    [SerializeField] float maximumSpeed=10f;
    [SerializeField] float slowingDownDistance;
    [SerializeField] float stopDistance;
    [SerializeField] float distance;
    [SerializeField] float steeringSpeed = 2;
    [SerializeField] Rigidbody rb;
    [SerializeField] private float seperationForce;
    [SerializeField]BeeDisatcher beedispatcher;
    [SerializeField]List<PeasantBees> neighbourPeassants = new();
    
    public void SwitchTargets(Transform targetToFollow)
    {
        this.target1 = targetToFollow;
        this.flowerTarget = targetToFollow;
    }
    void Start()
    {
        rb.useGravity = false;
        
    }


    void Update()
    {

        if (neighbourPeassants.Count > 0)
        {
            Seperate();
            
        }
        if (target1 != null)
        {
            SeekTarget();
            float ratio  =Arrive();
            LimitVelocity(maximumSpeed * ratio);
        }
        this.transform.forward = rb.velocity;
    }

    private void Seperate()
    {
        Vector3 seperationDirection = Vector3.zero;
        for (int i = 0; i < neighbourPeassants.Count; i++)
        {
            seperationDirection += (this.transform.position - neighbourPeassants[i].transform.position);
        }
        rb.velocity += seperationDirection.normalized * seperationForce;
    }

    public void SeekTarget()
    {
        if (beedispatcher.dispatch == true )
        {
            direction = (flowerTarget.transform.position - transform.position).normalized;
            rb.velocity += direction * steeringSpeed;
            Arrive();
        }
        else
        {
            direction = (target1.transform.position - transform.position).normalized;
            rb.velocity += direction * steeringSpeed;
            Arrive();
        }
        
    }

    public float Arrive()
    {
        distance = Vector3.Distance(target1.transform.position, transform.position);
        if (distance > 5)
        {
            return 1;
        }
        if (distance > 1)
        {
            return .8f;
        }
        if (distance > .7f)
        {
            return .5f;
        }
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maximumSpeed);
        return 0;
        
        

    }

    void LimitVelocity(float speed)
    {
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PeassantBees"))
        {
            var neighbour = other.GetComponent<PeasantBees>();
            if (!neighbourPeassants.Contains(neighbour)&& neighbour)
            {
                neighbourPeassants.Add(neighbour);
            }
        }
        //add to the list
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PeassantBees"))
        {
            var neighbour = other.GetComponent<PeasantBees>();
            if (neighbourPeassants.Contains(neighbour))
            {
                neighbourPeassants.Remove(neighbour);
            }
        }

    }
}
