
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
    [SerializeField] NectarBar beeNectarScript;
    public float collectingNectarRate;
    
    [SerializeField]bool nectarIsAvailable;
    [SerializeField] TextMeshProUGUI nectarLeftInTheFlowerText;
    [SerializeField] GameObject flowerNectarCanvas;
    [SerializeField] BeeDisatcher beeDispatcherScript;
    [SerializeField] PeasantBees peassant;
    public List<PeasantBees> beesInFlowers = new ();


    //I need to add amount of nectar to flowers, a timer, and collision detector
    void Start()
    {
        beeDispatcherScript = GameObject.Find("player").GetComponent<BeeDisatcher>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log( flowerNectarAmount);
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

            //FlowerLosingNectar();

            if (nectarIsAvailable==true)
            {
                
                //beeNectarScript.BeesGainingNectar();
            }

            flowerNectarCanvas.SetActive(true);
            nectarLeftInTheFlowerText.text = this.flowerNectarAmount.ToString("0");
            if (Input.GetKeyDown(KeyCode.E) && nectarIsAvailable == false)
            {
                Destroy(this.flower);
            }


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PeassantBees"))
        {
            flowerNectarCanvas.SetActive(false);

        }
        
    }


    public void FlowerLosingNectar ()
    {

        if (nectarIsAvailable==true)
        {
            //I want flower nectar to get drained when player is colliding with it
            this.flowerNectarAmount -= 1 * collectingNectarRate * Time.deltaTime ;
            
        }

    }

    void nectarAmountCheck()
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
