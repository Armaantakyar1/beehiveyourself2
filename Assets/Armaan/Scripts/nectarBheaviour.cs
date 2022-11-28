using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nectarBheaviour : MonoBehaviour
{
    
    [SerializeField] FlowerBehaviour flowersNectar;
    public float nectaramount;
    [SerializeField] float collectionTimer = 5f;
    [SerializeField] bool collectionStart;
    // Start is called before the first frame update
    void Start()
    {
        nectaramount = flowersNectar.flowerNectarAmount;
    }

    // Update is called once per frame
    void Update()
    {
        nectarchange();
    }
    public void nectarchange()
    {
        
        if (collectionStart == true)
        {
            Debug.Log("pog");
            collectionTimer -= Time.deltaTime;
            if (collectionTimer <= 0)
            {
                BeesGainingNectar();
                FlowerLosingNectar();
                collectionTimer = 5f;
            }
        }
    }
    public void BeesGainingNectar()
    {

        nectaramount += 1;//* flowersNectar.collectingNectarRate * Time.deltaTime;

        Debug.Log("bee gaining nectar");
    }
    public void FlowerLosingNectar()
    {

        if (flowersNectar.nectarIsAvailable == true)
        {
      
            this.flowersNectar.flowerNectarAmount -= 1;//* flowersNectar.collectingNectarRate * Time.deltaTime;

        }

    }
    public void startCollection()
    {
        

        collectionStart = true;
    }

    public void stopCollection()
    {
        collectionStart = false;
    }
}
