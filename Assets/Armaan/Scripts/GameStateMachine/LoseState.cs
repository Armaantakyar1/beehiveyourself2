using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoseState : MonoBehaviour
{
    PlayState play;

    private void Start()
    {
        PlayState play = GetComponent<PlayState>();
    }
    private void Update()
    {
        Disable();
        restartlevel();
    }
    public void Disable()
    {
        play.enabled = false;
    }
    public void restartlevel()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    
}
