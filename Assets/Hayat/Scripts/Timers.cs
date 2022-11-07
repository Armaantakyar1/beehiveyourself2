using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timers : MonoBehaviour
{
    [SerializeField] float worldTimer = 100;
    [SerializeField] Text worldTimerText;
    public bool inBeehive;
    [SerializeField] GameObject restartButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.SetActive(false);
    }

    void levelTimer()
    {
        if (worldTimer >= 0)
        {
            worldTimer -= 1 * Time.deltaTime;
            worldTimerText.text = worldTimer.ToString("0");
        }
    }

    void NotInBeehiveGameOver()
    {
        if (inBeehive==false)
        {
            if (worldTimer <= 0)
            {
                //gameover
                restartButton.SetActive(true);
                Time.timeScale = 0;
            }

        }
    }

   
    // Update is called once per frame
    void Update()
    {
        levelTimer();
        NotInBeehiveGameOver();
    }
}
