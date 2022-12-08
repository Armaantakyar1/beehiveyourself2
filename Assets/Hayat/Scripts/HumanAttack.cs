using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAttack : MonoBehaviour
{
    public Vector3 originalPosition;
    [SerializeField] int maxDistance;
    [SerializeField] AggressionMeter human;
    [SerializeField] PeasantBees peasants;
    [SerializeField] HumanWandering humanMovement;
    void Start()
    {
        originalPosition = humanMovement.rb.transform.position;
        
    }
    public void HumanAttacking()
    {

        if (human.humanAggressionAmount >= human.humanMaxAggressionAmount)
        {
            var direction = ( peasants.beeTarget.transform.position - transform.position).normalized;
            humanMovement.rb.velocity += direction * humanMovement.speed * Time.deltaTime; //human movies towards bee
            humanMovement.isInspecting = false;
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
