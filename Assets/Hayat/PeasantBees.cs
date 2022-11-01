using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantBees : MonoBehaviour
{
   // [SerializeField] Vector3 Target;
    //[SerializeField] GameObject LeaderBee;
    Targets target;
    Vector3 Direction;
    [SerializeField] float MaximumVelocity=10f;
    [SerializeField] float SlowingDownDistance;
    [SerializeField] float StopDistance;
    [SerializeField] float distance;
    [SerializeField] float speed = 2;
    [SerializeField]Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        SeekLeaderBee();
        Truncate();
        //Arrive();
    }

    void SeekLeaderBee()
    {
        target.Target1 = target.LeaderBee.transform.position;
        Direction = (target.Target1 - transform.position).normalized * speed;
        rb.velocity += Direction;
        if (rb.velocity.magnitude> MaximumVelocity)
        {
            rb.velocity = rb.velocity.normalized * MaximumVelocity;
        }
    }

    float Arrive()
    {
        distance = Vector3.Distance(a: target.Target1, b: transform.position);
        /*if (distance>SlowingDownDistance)
        {
            return 1;
        }

        if (distance<SlowingDownDistance)
        {
            return 0;
        }*/
        if (SlowingDownDistance==5)
        {
            return 5;
        }
        if (SlowingDownDistance == 3)
        {
            return 3;
        }
        if (SlowingDownDistance == 2)
        {
            return 2;
        }
        speed = 1 / (SlowingDownDistance - StopDistance);
        return speed * (distance - StopDistance);


    }
    void Truncate()
    {
        speed = Arrive();
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed ;
        }
    }
}
