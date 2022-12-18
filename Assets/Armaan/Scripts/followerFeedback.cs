using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followerFeedback : MonoBehaviour
{
    public int increment;
    [SerializeField]int maxDisabled = 2;
    public void changeFeedback()
    {
        transform.GetChild(increment).gameObject.SetActive(false);
        if(increment != maxDisabled)
        {
            increment++;
        }
        
    }
}
