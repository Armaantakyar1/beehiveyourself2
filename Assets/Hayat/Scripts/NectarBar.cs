using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NectarBar : MonoBehaviour
{
    public float beeNectarAmount;
    [SerializeField] FlowerBehaviour flowersNectar;
    [SerializeField] TextMeshProUGUI nectarAmountText;
    public bool collectionstart = true;

                    
    private void Update()
    {
        nectarAmountText.text = beeNectarAmount.ToString("Nectar Amount: 0");



    }


    public void BeesGainingNectar()
    {
        
            beeNectarAmount += 1 * flowersNectar.collectingNectarRate * Time.deltaTime;
        
        Debug.Log("bee gaining nectar");
    }

}
