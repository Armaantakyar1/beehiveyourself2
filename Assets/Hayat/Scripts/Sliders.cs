using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    // Update is called once per frame
    public void SetValue( float specificValue)
    {
        slider.value = specificValue;

    }
    public void SetMaxValue(float specificValue)
    {
        slider.maxValue = specificValue;
        slider.value = specificValue;
    }
}
