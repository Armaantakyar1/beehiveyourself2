using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanStateMachine : MonoBehaviour
{
    HumanStates state;


    //wandering variables
    [SerializeField] float speed;
    [SerializeField] float rotatingSpeed;
    [SerializeField] float rotatePause;
    [SerializeField] float rotatingDuration;
    [SerializeField] float walkTime;
    bool isWandering = false;
    bool isWalking = false;
    bool isRotating = false;
    Rigidbody rb;
    bool humanIsAttacking = false;
    Vector3 originalPosition;
    [SerializeField] PeasantBees peasantBees;
    [SerializeField] AggressionMeter aggressionMeter;
    [SerializeField] float timerBeforeAttacking;
    enum HumanStates
    {
        wanderingState,
        staringAtBees,
        attackingBees,
        goingBackToPosition
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        peasantBees.GetComponent<PeasantBees>();
        aggressionMeter.GetComponent<AggressionMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        wanderingHuman();
        HumanInspectingBees();
        GoingBackToPosition();
    }

    void wanderingHuman()
    {
        
        if (isWandering == false && humanIsAttacking==false)
        {
            StartCoroutine(Wander());
        }

        if (isRotating == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotatingSpeed);
        }

        if (isWalking == true)
        {
            //rb.velocity += new Vector3(1,0,1) * speed * Time.deltaTime;
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        IEnumerator Wander()
        {
            state = HumanStates.wanderingState;
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

    void HumanAttacking()
    {

        if (aggressionMeter.humanAggressionAmount >= aggressionMeter.humanMaxAggressionAmount)
        {            
            state = HumanStates.attackingBees;
            var direction = (peasantBees.beeTarget.transform.position - transform.position).normalized;
            rb.velocity += direction * speed * Time.deltaTime; //human movies towards bee
            humanIsAttacking = true;
        }
    }

    void HumanInspectingBees()
    {
        state = HumanStates.staringAtBees;
        //stop moving and turn to bees
        rb.velocity = Vector3.zero;
        timerBeforeAttacking -= Time.deltaTime;
        if (timerBeforeAttacking<= 0)
        {
            HumanAttacking();
        }
    }

    void GoingBackToPosition()
    {
        state = HumanStates.goingBackToPosition;
        var direction = (originalPosition - transform.position).normalized;
        rb.velocity += direction * speed * Time.deltaTime;

    }
}
