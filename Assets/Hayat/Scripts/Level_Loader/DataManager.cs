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
            isPaused = true;
        }
        if (Input.GetKey(KeyCode.Escape) && isPaused == true)
        {
            canvas.SetActive(false);
            isPaused = false;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("input detected");
            SavePlayer();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            LoadPlayer();
        }
    }
    public void SavePlayer()
    {
        SavingSystem.Saving(GetComponent<movement>());
        Debug.Log("Saving");
    }
    
    public void LoadPlayer()
    {
        PlayerData data = SavingSystem.Load();
       // GetComponent<nectarBheaviour>().nectaramount = data.nectar;
        //GetComponent<AggressionMeter>().beeAggressionAmount = data.aggression;
        Vector3 position;
        Debug.Log("Loading");
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];
        position.z = data.playerPosition[2];
        transform.position = position;
        
    }
}
