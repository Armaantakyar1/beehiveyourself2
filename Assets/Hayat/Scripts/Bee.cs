using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bee : MonoBehaviour
{
    [SerializeField] GameObject beeHive;
    [SerializeField] Timers timerScript;
    [SerializeField] HumanWandering human;
    [SerializeField] GameObject canvas;
    bool isPaused;

    private void Start()
    {
        isPaused = false;
        canvas.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            //canvas.SetActive(true);
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            canvas.SetActive(true);
            Time.timeScale = 0;
        }
        else canvas.SetActive(false);
        Time.timeScale = 1;
        /*if (Input.GetKey(KeyCode.Escape) && isPaused == true)
        {
            canvas.SetActive(false);
            isPaused = false;
        }*/

            void OnTriggerEnter(Collider other)
            {
                if (other.gameObject == beeHive)
                {
                    timerScript.inBeehive = true;
                    Debug.Log("bees are in the beehive");
                }
            }
            void OnTriggerExit(Collider other)
            {
                if (other.CompareTag("Reset"))
                {
                    human.isInspecting = false;
                    human.timerBeforeAttacking = human.maxTimerBeforeAttacking;
                }
            }
        }
    }


