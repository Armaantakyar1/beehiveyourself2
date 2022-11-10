
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBehaviour : MonoBehaviour
{
    public float flowerNectarAmount;
    [SerializeField]int numberOfBes;
    public float collectingNectarRate;
    public List<PeasantBees> bees = new();


    //I need to add amount of nectar to flowers, a timer, and collision detector
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log( flowerNectarAmount);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PeassantBees"))
        {
            if(other.GetComponent<PeasantBees>() != null) {
                
                PeasantBees pBee = other.GetComponent<PeasantBees>();
                bees.Add(pBee);
            }
        }

    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FlowerLosingNectar();
        }
    }



    /*private void OnTriggerEnter(Collision collision)
    {
        if(collision.gameObject.tag== "Player")
        {
            CollectingNectar();
        }

    }*/

    public void FlowerLosingNectar ()
    {

        if (flowerNectarAmount > 0)
        {
            //I want flower nectar to get drained when player is colliding with it
            //yield return new WaitForSecondsRealtime(1);
            flowerNectarAmount -= 1 * collectingNectarRate * Time.deltaTime ;
            //Invoke("CollectingNectar", 5);
        }

    }
}
