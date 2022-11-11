using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NectarBar : MonoBehaviour
{
    public float beeNectarAmount;
    [SerializeField] FlowerBehaviour flowersNectar;
    //[SerializeField] GameObject flowerPrefab;
    //I need to figure out how to get the bee to read the information of the flower its colliding with
     void Start()
     {
        
     }
    private void Update()
    {
    }


    public void BeesGainingNectar()
    {
        
            beeNectarAmount += 1 * flowersNectar.collectingNectarRate * Time.deltaTime;
        
        Debug.Log("bee gaining nectar");
    }

}
