using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantBees : MonoBehaviour
{
    [SerializeField] Vector3 Target;
    [SerializeField] GameObject LeaderBee;
    Vector3 Direction;
    float MaximumVelocity=10f;
    int speed = 2;
    [SerializeField]Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
                SeekLeaderBee();
    }

    void SeekLeaderBee()
    {
        Target = LeaderBee.transform.position;
        Direction = (Target - transform.position).normalized * speed;
        rb.velocity += Direction;
        if (rb.velocity.magnitude> MaximumVelocity)
        {
            rb.velocity = rb.velocity.normalized * MaximumVelocity;
        }
    }
}
