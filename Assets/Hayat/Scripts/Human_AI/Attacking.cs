using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public Transform beeTarget;
    Rigidbody rb;
    AggressionMeter human;
    PeasantBees peasants;
    Patroling patroling;
    bool isAttacking;

    [SerializeField] float chasingTimer;
    [SerializeField] float maxTimer;
    void Start()
    {
        GetComponent<Patroling>().enabled = false;
        GetComponent<Inspecting>().enabled = false;
        GetComponent<SeekingBehaviour>().SetTarget(beeTarget.position);
        human = GetComponent<AggressionMeter>();
        peasants = GetComponent<PeasantBees>();
        patroling = GetComponent<Patroling>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (human.humanAggressionAmount >= human.humanMaxAggressionAmount)
        {
            GetComponent<SeekingBehaviour>().Seek();
            GetComponent<SeekingBehaviour>().SetTarget(beeTarget.position);
            isAttacking = true;
            chasingTimer += Time.deltaTime;
            if (chasingTimer>= maxTimer)
            {
                human.humanAggressionAmount = 0;
                isAttacking = false;
                GetComponent<Patroling>().enabled = true;
                this.enabled = false;

            }


        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PeassantBees") && isAttacking==true)
        {
            //Destroy(peasants.neighbourPeassants[Random.Range(2,4)], 0.5f); //not sure if this actually destoys random elements..
        }
    }

}
