using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingNectar : MonoBehaviour
{
    [SerializeField] int NectarBar;
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
