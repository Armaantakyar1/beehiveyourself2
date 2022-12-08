using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanWandering : MonoBehaviour
{
    public float speed;
    [SerializeField] float rotatingSpeed;

    [SerializeField] float rotatePause;
    [SerializeField] float rotatingDuration;
    [SerializeField] float walkTime;
    //[SerializeField] float walkWait;

    bool isWandering = false;
    bool isWalking = false;
    bool isRotating=false;
    public Rigidbody rb;
    public bool humanIsAttacking = false;
    public bool isInspecting;
    [SerializeField] PeasantBees peasantBees;
    [SerializeField] AggressionMeter aggressionMeter;
    [SerializeField] HumanAttack humanAttack;
    [SerializeField] float timerBeforeAttacking;
    [SerializeField] float maxTimerBeforeAttacking;
    [SerializeField] float timerRate;

    void HumanInspectingBees()
    {
        //stop moving and turn to bees
        isInspecting = true;
        if (humanIsAttacking == true)
        {
            humanAttack.HumanAttacking();
            Debug.Log("human is gonna attack");
        }
        if (timerBeforeAttacking >= 0)
        {
            timerBeforeAttacking -= timerRate * Time.deltaTime;
        }
        if (timerBeforeAttacking <= 0)
        {
            isInspecting = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            HumanInspectingBees();
        }
    }
    /*private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //timerBeforeAttacking = maxTimerBeforeAttacking; use this when you make the going back to position function
        }
    }*/

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (isWandering==false && humanIsAttacking == false && isInspecting==false)
        {
            StartCoroutine(Wander());
        }

        if (isInspecting==true)
        {
            StopCoroutine(Wander());
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
