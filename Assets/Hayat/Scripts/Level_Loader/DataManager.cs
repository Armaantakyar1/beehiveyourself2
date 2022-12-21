using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    bool isPaused;

    private void Start()
    {
        isPaused = false;
        canvas.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && isPaused == false)
        {
            canvas.SetActive(true);
            isPaused = true; ;
        }
        if (Input.GetKey(KeyCode.Escape) && isPaused == true)
        {
            canvas.SetActive(false);
            isPaused = false;
        }
    }
    public void SavePlayer()
    {
        SavingSystem.Saving();
    }
    
    public void LoadPlayer()
    {
        PlayerData data = SavingSystem.Load();
        GetComponent<nectarBheaviour>().nectaramount = data.nectar;
        GetComponent<AggressionMeter>().beeAggressionAmount = data.aggression;
        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];
        position.z = data.playerPosition[2];
        transform.position = position;
        
    }
}
