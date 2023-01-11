using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathState : MonoBehaviour
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
    public void restartlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Disable()
    {
        play.enabled = false;
    }
}
