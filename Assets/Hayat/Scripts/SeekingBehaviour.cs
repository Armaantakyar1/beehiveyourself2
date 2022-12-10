using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingBehaviour : MonoBehaviour
{
    public Transform Target;
    public Rigidbody rb;
    public float speed;
    public float maxSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        
    }
    public void Seek(Vector3 vector)
    {
        var direction = Target.transform.position - transform.position;
        rb.velocity += direction * speed;
        transform.LookAt(Target);
        Truncate();
    }

    public void Arrive()
    {
        var distance = Vector3.Distance(Target.transform.position, transform.position);
        if (distance <= 0.3f)
        {
            rb.velocity = Vector3.zero;
        }
    }
    public void Truncate()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        Arrive();
    }
    public void SetTarget(Vector3 targetPositions)
    {
        targetPositions = Target.transform.position;

    }
    


}
