using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nectarBheaviour : MonoBehaviour
{
    
    [SerializeField] FlowerBehaviour flowersNectar;
    public float nectaramount;
    [SerializeField] float collectionTimer = 0f;
    [SerializeField] bool collectionStart;
    [SerializeField] Sliders slider;
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
         slider.SetValue(nectaramount);
    }
    public void nectarchange()
    {  
            collectionTimer -= Time.deltaTime;
            if (collectionTimer <= 0)
            {
                BeesGainingNectar();
            flowersNectar.FlowerLosingNectar();
            collectionTimer = 1f;
            }
        
    }
    public void BeesGainingNectar()
    {
        
        nectaramount = nectaramount + 1;
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
