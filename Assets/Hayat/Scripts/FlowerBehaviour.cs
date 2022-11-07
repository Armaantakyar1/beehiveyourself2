using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBehaviour : MonoBehaviour
{
    public int NectarAmount;
    [SerializeField]int numberOfBes;
    public List<PeasantBees> bees = new();


    //I need to add amount of nectar to flowers, a timer, and collision detector
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PeassantBees"))
        {
            if(other.GetComponent<PeasantBees>() != null) {
                //bees.Add(other.gameObject);
                PeasantBees pBee = other.GetComponent<PeasantBees>();
                bees.Add(pBee);
            }
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag== "Player")
        CollectingNectar();
        Debug.Log(NectarAmount);
    }

    public void CollectingNectar ()
    {
        if (NectarAmount >= 0)
        {
            //yield return new WaitForSecondsRealtime(1);
            NectarAmount -= 1;
            Invoke("CollectingNectar", 5);
        }
    }
}
