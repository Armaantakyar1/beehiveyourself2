
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlowerBehaviour : MonoBehaviour
{
    public float flowerNectarAmount;
    [SerializeField]Transform flowerPosition;
    [SerializeField] GameObject flower;
    [SerializeField]int numberOfBes;
    //[SerializeField] nectarBheaviour beeNectarScript;
    public float collectingNectarRate;
    public List<PeasantBees> beesInFlowers = new();
    public bool nectarIsAvailable = true;
    [SerializeField] BeeDisatcher beeDispatcherScript;
    [SerializeField] GameObject LeaderBee;
    [SerializeField] nectarBheaviour beeNectarScript;


    //I need to add amount of nectar to flowers, a timer, and collision detector
    void Start()
    {
        beeDispatcherScript = GameObject.Find("player").GetComponent<BeeDisatcher>();

    }

    // Update is called once per frame
    void Update()
    {
        
        nectarAmountCheck();


    }
    private void OnTriggerEnter(Collider other)
    {
        if (beesInFlowers.Count >= 1)
        {
            return;
        }
        if (other.CompareTag("PeassantBees"))
        {
            var bee = other.GetComponent<PeasantBees>();
            
            if (bee != null) 
            {
                bee.flowerTarget = this.flowerPosition;
                beesInFlowers.Add(bee);
                
            }

        }

    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PeassantBees") && beeDispatcherScript.dispatch==true)
        {
           
            if (nectarIsAvailable==true)
            {
                beeNectarScript.startCollection();
                Debug.Log("lalalalal");
            }
            if(nectarIsAvailable == false)
            {
                beeNectarScript.stopCollection();
            }

            if (Input.GetKeyDown(KeyCode.E) && nectarIsAvailable == false)
            {
                Destroy(this.flower);
            }


        }
    }

    public void nectarAmountCheck()
    {
        if (flowerNectarAmount <= 0)
        {
            nectarIsAvailable = false;
        }
        if (flowerNectarAmount > 0)
        {
            nectarIsAvailable = true;
        }
    }


}



