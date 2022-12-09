using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAttack : MonoBehaviour
{
    public Vector3 originalPosition;
    [SerializeField] float speed;
    [SerializeField] int maxDistance;
    Vector3 desiredVelocity;
    Vector3 currentVelocity;
    Vector3 steeringVelocity;
    AggressionMeter human;
    [SerializeField] PeasantBees peasants;
    HumanWandering humanMovement;
    void Start()
    {
        //originalPosition = humanMovement.rb.transform.position;
        human = GetComponent<AggressionMeter>();
        peasants = GetComponent<PeasantBees>();
        humanMovement = GetComponent<HumanWandering>();

    }
    public void HumanAttacking()
    {

        if (human.humanAggressionAmount >= human.humanMaxAggressionAmount && humanMovement.isInspecting == false)
        {
            desiredVelocity = ( peasants.beeTarget.transform.position -transform.position);
            //desiredVelocity *= speed;
            steeringVelocity = (desiredVelocity - currentVelocity);
            steeringVelocity = Vector3.ClampMagnitude(steeringVelocity, speed);
            currentVelocity += steeringVelocity;
            humanMovement.rb.velocity += desiredVelocity * speed * Time.deltaTime; //human movies towards bee

            humanMovement.isInspecting = false;
            humanMovement.humanIsAttacking = true;
        }
    }

    void GoingBackToPosition()
    {
        var distance = Vector3.Distance(originalPosition, transform.position);
        var direction = (transform.position - originalPosition).normalized;
        if (distance>= maxDistance)
        {
            if (transform.position!=originalPosition)
            {
                humanMovement.rb.velocity += direction * humanMovement.speed * Time.deltaTime;
            }
        }
        humanMovement.isInspecting = true;

    }
    // Update is called once per frame
    void Update()
    {

        //HumanAttacking();
        //GoingBackToPosition();
    }
}
