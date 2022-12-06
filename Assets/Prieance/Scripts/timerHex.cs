using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerHex : MonoBehaviour
{
    public Image filler;
   
    public void SetMaxTime()
    {
        filler.fillAmount = 300;
    }

    public void Timer()
    {
        if(filler.fillAmount >= 300)
        {
            filler.fillAmount -= 1 * Time.deltaTime;
        }
    }
}
