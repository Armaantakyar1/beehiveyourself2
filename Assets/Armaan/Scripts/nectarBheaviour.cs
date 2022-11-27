using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nectarBheaviour : MonoBehaviour
{
    public float nectaramount;
    [SerializeField] FlowerBehaviour flowersNectar;
    [SerializeField] float collectionTimer = 5f;
    public bool collectionStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(collectionStart == true)
        {
            collectionTimer -= Time.deltaTime;
            if(collectionTimer<= 0)
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
}
