using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingBehaviour : MonoBehaviour
{
    public Vector3 target;
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
    public void Seek()
    {
        var direction = target - this.transform.position;
        rb.velocity += direction * speed;
        this.transform.LookAt(target);
        Truncate();
    }

    public void Arrive()
    {
        var distance = Vector3.Distance(target, transform.position);
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
        this.target= targetPositions;
    }


}
