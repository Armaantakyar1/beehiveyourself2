using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class Serialization : MonoBehaviour
{
    [SerializeField] Slider nectar;
    [SerializeField] Slider agression;
    movement move;
    private void Start()
    {
        move = GetComponent<movement>();
    }
    public void SaveGame()
    {
        PlayerData playerData = new PlayerData();
        playerData.nectarSlider = nectar.value;
        playerData.aggressionSlider = agression.value;
        playerData.position = move.transform.position;
        string path = "/GameData.json";

        string turnThisToJSON = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.dataPath + path, turnThisToJSON);
        Debug.Log(turnThisToJSON); 
    }

    public void LoadGame()
    {
        string path = "/GameData.json";
        string readthis = File.ReadAllText(Application.dataPath + path);
        PlayerData pdata = JsonUtility.FromJson<PlayerData>(readthis);
        nectar.value = pdata.nectarSlider;
        agression.value = pdata.aggressionSlider;
        move.transform.position = pdata.position;
        Debug.Log(pdata);

    }





    public class PlayerData
{
       public float nectarSlider;
       public float aggressionSlider;
       public Vector3 position;

        /* public float nectar;
         public float aggression;
         public float[] playerPosition;
         [SerializeField] GameObject playerBee;
         public PlayerData(movement move)
         {
             //nectar = GetComponent<nectarBheaviour>().nectaramount;
             //aggression = GetComponent<AggressionMeter>().beeAggressionAmount;
             playerPosition = new float[3];
             playerPosition[0] = move.transform.position.x;
             playerPosition[1] = move.transform.position.y;
             playerPosition[2] = move.transform.position.z;

         }*/
    }
}

