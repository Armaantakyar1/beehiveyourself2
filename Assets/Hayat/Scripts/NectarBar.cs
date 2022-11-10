using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NectarBar : MonoBehaviour
{
    [SerializeField] float beeNectarAmount;
    [SerializeField] FlowerBehaviour flowersNectar;
    //pinkFlowers FlowerNectar;
     void Start()
    {

    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Flowers"))
        {
            if (flowersNectar.flowerNectarAmount > 0)
            {
                BeesGainingNectar();
            }
        }
    }

    void BeesGainingNectar()
    {
        
            beeNectarAmount += 1 * flowersNectar.collectingNectarRate * Time.deltaTime;
        
    }

}
