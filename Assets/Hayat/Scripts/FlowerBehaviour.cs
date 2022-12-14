
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
    [SerializeField] float collectionTimer = 0f;
    //[SerializeField] nectarBheaviour beeNectarScript;
    public float collectingNectarRate;
    public List<PeasantBees> beesInFlowers = new();
    public bool nectarIsAvailable = true;
    bool collectionStart ;
    [SerializeField] TextMeshProUGUI nectarLeftInTheFlowerText;
    [SerializeField] GameObject flowerNectarCanvas;
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
        if (collectionStart == true)
        {
            FlowerLosingNectar();
        }


    }
    public void FlowerLosingNectar()
    {
        collectionTimer -= Time.deltaTime;
        if (collectionTimer<=0)
        {
            flowerNectarAmount = flowerNectarAmount - 1;
            beeNectarScript.BeesGainingNectar();
        }

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

                collectionStart = true;

            }
            if(nectarIsAvailable == false)
            {
                collectionStart = false;
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



