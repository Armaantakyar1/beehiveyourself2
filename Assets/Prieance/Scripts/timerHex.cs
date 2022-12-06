using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerHex : MonoBehaviour
{
    public Image filler;
    public float gameTime;
    public void SetMaxTime()
    {
        filler.fillAmount = gameTime;
    }
    private void Update()
    {
        Timer();
        
    }

    public void Timer()
    {
        filler.fillAmount -= Time.deltaTime / gameTime;

    }
}
