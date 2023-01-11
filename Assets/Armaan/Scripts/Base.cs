using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    WinState win;
    LoseState loose;
    nectarBheaviour nectar;
    public int winnerAmount;
    private void Start()
    {
        nectarBheaviour nectar = GetComponent<nectarBheaviour>();
        WinState win = GetComponent<WinState>();
        LoseState loose = GetComponent<LoseState>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(nectar.nectaramount >= winnerAmount)
        {
            win.enabled = true;
        }
        else
        {
            loose.enabled = true;
        }
    }
}
