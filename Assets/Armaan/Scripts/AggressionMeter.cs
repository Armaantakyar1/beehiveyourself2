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
    [SerializeField]bool inRadius;
    [SerializeField] float collectionTimer;
    [SerializeField] Sliders slider;

    // Start is called before the first frame update
    void Start()
    {
        PeasantBees peasants = GetComponent<PeasantBees>();
        //slider = GetComponent<Sliders>();
        slider.SetMaxValue(beeMaxAggressionAmount);

    }

    // Update is called once per frame
    void Update()
    {
      
        if (inRadius == true)
        {
            collectionTimer = collectionTimer - Time.deltaTime;
            if (collectionTimer <= 0)
            {

                Agreesiontimer();
                
            }
            if (beeAggressionAmount >= beeMaxAggressionAmount)
            {
                peasants.AngryBee();
            }
        }
        if (humanAggressionAmount >= humanMaxAggressionAmount)
        {
            human.humanIsAttacking = true;
        }
        slider.SetValue(beeAggressionAmount);
        Debug.Log("bee slider should move");
    }

    void Agreesiontimer()
    {
         if (beeAggressionAmount <= beeMaxAggressionAmount)
         {
              beeAggressionAmount += 1;
              collectionTimer = 5f;
         }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PeassantBees"))
        {
            inRadius = true;
        }
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
            
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PeassantBees"))
        {
            inRadius = false;
        }
    }


}
