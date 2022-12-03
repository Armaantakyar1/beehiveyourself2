using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressionMeter : MonoBehaviour
{

    public List<PeasantBees> seekingbees = new ();
    [SerializeField] Transform obstacleposition;
    public float humanAggressionAmount;
    public float humanMaxAggressionAmount;
    public float beeAggressionAmount;
    public float beeMaxAggressionAmount;
    public float aggressionRate;
    [SerializeField]PeasantBees peasants;
    [SerializeField] HumanWandering human;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beeAggressionAmount >= beeMaxAggressionAmount)
        {
            peasants.pissedOff = true;
        }
        if (humanAggressionAmount >= humanMaxAggressionAmount)
        {
            human.humanIsAttacking = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (seekingbees.Count > 3)
        {
            return;
        }
        if (other.CompareTag("PeassantBees"))
        {
            var bee = other.GetComponent<PeasantBees>();

            if (bee != null)
            {
                bee.obstacle = this.obstacleposition;
                seekingbees.Add(bee);
            }

        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PeassantBees"))
        {
            if (humanAggressionAmount<= humanMaxAggressionAmount)
            {
                humanAggressionAmount += 1 * aggressionRate * Time.deltaTime;
            }
            if (beeAggressionAmount <= beeMaxAggressionAmount)
            {
                beeAggressionAmount += 1 * aggressionRate * Time.deltaTime;
            }
        }

    }


}
