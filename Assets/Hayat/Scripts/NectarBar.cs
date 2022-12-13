using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NectarBar : MonoBehaviour
{
    public float beeNectarAmount;
    public float maxBeeNectar;
    [SerializeField] FlowerBehaviour flowersNectar;
    [SerializeField] TextMeshProUGUI nectarAmountText;
    [SerializeField] float collectionTimer;
    [SerializeField] Sliders slider;
    void Start()
    {
        ///slider = GetComponent<Sliders>();        
        slider.SetMaxValue(maxBeeNectar);

    }
    private void Update()
    {
        slider.SetValue(beeNectarAmount);

        nectarAmountText.text = beeNectarAmount.ToString("Nectar Amount: 0");

       
    }


   

}
