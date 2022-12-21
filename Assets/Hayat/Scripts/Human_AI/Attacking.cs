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
    [SerializeField] float killTimer;
    [SerializeField] float maxKillTimer;
    public float chasingTimer;
    [SerializeField] float maxChasingTimer;

    [SerializeField] List<GameObject> beesNear = new List<GameObject>();
    void Start()
    {
        patroling.enabled = false;
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
        GetComponent<SeekingBehaviour>().SetTarget(beeTarget.position);
        Debug.Log(beesNear.Count);
        GetComponent<SeekingBehaviour>().Seek();
        isAttacking = true;

        if (chasingTimer<= maxChasingTimer)
        {
            chasingTimer += Time.deltaTime;
        }

        if (chasingTimer>= maxChasingTimer)
        {
            human.humanAggressionAmount = 0;
            isAttacking = false;
            chasingTimer = 0;
            this.enabled = false;
            patroling.enabled = true;
            
        }

        //beesNear.Sort();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PeassantBees") && !beesNear.Contains(other.gameObject) && isAttacking==true)
        {
            beesNear.Add(other.gameObject);            
            killTimer += Time.deltaTime;

            if (killTimer >= maxKillTimer)
            {
                Destroy(beesNear[Random.Range(2, 7)], 0.5f);
                killTimer = 0;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        beesNear.Remove(other.gameObject);
    }

    void SortingTheBees(GameObject[] array)
    {
        var beesDistance = Vector3.Distance(peasants.transform.position, transform.position);
        //beesNear list should be the array here 
        for (int i = 0; i< array.Length; i++)
        {
            for (int j=i+1; j <array.Length; j++)
            {
                if (beesDistance<=3)
                {

                }
            }
        }
    }
}
