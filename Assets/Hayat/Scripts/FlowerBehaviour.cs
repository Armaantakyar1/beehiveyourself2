
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlowerBehaviour : MonoBehaviour
{
    public float flowerNectarAmount;
    [SerializeField]int numberOfBes;
    [SerializeField] NectarBar beeNectarScript;
    public float collectingNectarRate;
    public List<PeasantBees> bees = new();
    bool nectarIsAvailable;
    [SerializeField] TextMeshProUGUI nectarLeftInTheFlowerText;
    [SerializeField] GameObject flowerNectarCanvas;

    //I need to add amount of nectar to flowers, a timer, and collision detector
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log( flowerNectarAmount);
        nectarAmountCheck();

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

            if (nectarIsAvailable==true)
            {
                beeNectarScript.BeesGainingNectar();
            }

            flowerNectarCanvas.SetActive(true);
            nectarLeftInTheFlowerText.text = this.flowerNectarAmount.ToString("0");


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flowerNectarCanvas.SetActive(false);

        }
    }


    public void FlowerLosingNectar ()
    {

        if (nectarIsAvailable==true)
        {
            //I want flower nectar to get drained when player is colliding with it
            flowerNectarAmount -= 1 * collectingNectarRate * Time.deltaTime ;
            
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
