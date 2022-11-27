using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanWandering : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotatingSpeed;

    [SerializeField] float rotatePause;
    [SerializeField] float rotatingDuration;
    [SerializeField] float walkTime;
    //[SerializeField] float walkWait;

    bool isWandering = false;
    bool isWalking = false;
    bool isRotating=false;
     Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (isWandering==false)
        {
            StartCoroutine(Wander());
        }

        if (isRotating==true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotatingSpeed);
        }

        if(isWalking==true)
        {
            //rb.velocity += new Vector3(1,0,1) * speed * Time.deltaTime;
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        IEnumerator Wander()
        {

            isWandering = true;
            isWalking = false;
            //yield return new WaitForSeconds(walkWait);
            isWalking = true;
            yield return new WaitForSeconds(walkTime);
            isWalking = false;
            isRotating = true;
            yield return new WaitForSeconds(rotatingDuration);
            isRotating = false;
            yield return new WaitForSeconds(rotatePause);
            
            
            isWandering = false;
        }
    }




}
