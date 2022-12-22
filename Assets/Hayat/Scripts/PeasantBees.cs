using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantBees : MonoBehaviour
{

    public Transform beeTarget;
    public Transform flowerTarget ;
    public Transform obstacle;
    Vector3 direction;
    [SerializeField] float maximumSpeed=10f;
    [SerializeField] float slowingDownDistance;
    [SerializeField] float stopDistance;
    [SerializeField] float distance;
    [SerializeField] float maximumDistanceFromLeader;
    [SerializeField] float catchingUpSpeed;
    [SerializeField] float steeringSpeed = 2;
    [SerializeField] Rigidbody rb;
    [SerializeField] private float seperationForce;
    [SerializeField]BeeDisatcher beedispatcher;
    public List<PeasantBees> neighbourPeassants = new();
    [SerializeField] bool pissedOff;

    public void SwitchTargets(Transform targetToFollow)
    {
        this.beeTarget = targetToFollow;
        this.flowerTarget = targetToFollow;
        this.obstacle = targetToFollow;
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
        if (beeTarget != null)
        {
            if (pissedOff == true)
            {
                seekobstacle();
            }
            else
            {
                SeekTarget();
            }
            float ratio  =Arrive();
            LimitVelocity(maximumSpeed * ratio);
        }
        this.transform.forward = rb.velocity;
    }
    public void AngryBee()
    {
        Debug.Log("pissedoff");
        pissedOff = true;
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
        if (beedispatcher.dispatch == true && flowerTarget != null )
        {
            direction = (flowerTarget.transform.position - transform.position).normalized;
            rb.velocity += direction * steeringSpeed;
            Arrive();
        }
        else
        {
            direction = (beeTarget.transform.position - transform.position).normalized;
            rb.velocity += direction * steeringSpeed;
            Arrive();

            if (distance > maximumDistanceFromLeader)
            {
                this.rb.velocity += direction * steeringSpeed * catchingUpSpeed;
            }
        }
        
    }

    public void seekobstacle()
    {

        if(obstacle!= null)
        {
            direction = (obstacle.transform.position - transform.position).normalized;
            rb.velocity += direction * steeringSpeed;
            Arrive();
        }

    }

    public float Arrive()
    {
        distance = Vector3.Distance(beeTarget.transform.position, transform.position);
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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle") && pissedOff == true)
        {
            this.gameObject.SetActive(false);
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
        if (other.CompareTag("Humans"))
        {
            Debug.Log("human");

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
