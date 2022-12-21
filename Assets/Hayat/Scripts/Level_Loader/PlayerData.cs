using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float nectar;
    public float aggression;
    public float[] playerPosition;
    [SerializeField] GameObject playerBee;
    public PlayerData()
    {
        nectar = GetComponent<nectarBheaviour>().nectaramount;
        aggression = GetComponent<AggressionMeter>().beeAggressionAmount;
        playerPosition = new float[3];
        playerPosition[0] = GetComponent<movement>().transform.position.x;
        playerPosition[1] = GetComponent<movement>().transform.position.y;
        playerPosition[2] = GetComponent<movement>().transform.position.z;

    }
}





