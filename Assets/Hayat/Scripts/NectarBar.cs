using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NectarBar : MonoBehaviour
{
    [SerializeField] int beeNectarAmount;
    FlowerBehaviour FlowersScript;
    //pinkFlowers FlowerNectar;
     void Start()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision. gameObject.tag =="Flowers")
        {
            if (FlowerNectar.NectarAmount>=0)
            {
                NectarBar += 1;
            }

            Debug.Log(NectarBar);
        }*/
    }

}
