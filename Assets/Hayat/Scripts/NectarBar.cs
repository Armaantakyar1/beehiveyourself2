using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NectarBar : MonoBehaviour
{
    public float beeNectarAmount;
    [SerializeField] FlowerBehaviour flowersNectar;
    [SerializeField] TextMeshProUGUI nectarAmountText;
    [SerializeField] float collectionTimer;
    void Start()
    {

    }
    private void Update()
    {
        nectarAmountText.text = beeNectarAmount.ToString("Nectar Amount: 0");

        collectionTimer -= Time.deltaTime;
        if (collectionTimer>0)
        {
            nectarAmountCheck();
            BeesGainingNectar();
            FlowerLosingNectar();

        }
    }


    public void BeesGainingNectar()
    {

        beeNectarAmount += 1 * flowersNectar.collectingNectarRate * Time.deltaTime;

        Debug.Log("bee gaining nectar");
    }
    public void FlowerLosingNectar()
    {

        if (flowersNectar.nectarIsAvailable == true)
        {
            //I want flower nectar to get drained when player is colliding with it
            this.flowersNectar.flowerNectarAmount -= 1 * flowersNectar.collectingNectarRate * Time.deltaTime;

        }

    }
    public void nectarAmountCheck()
    {
        if (flowersNectar.flowerNectarAmount < 0)
        {
            flowersNectar.nectarIsAvailable = false;
        }
        if (flowersNectar.flowerNectarAmount > 0)
        {
            flowersNectar.nectarIsAvailable = true;
        }
    }
}
