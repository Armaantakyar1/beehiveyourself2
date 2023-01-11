using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    PlayState play;

    private void Start()
    {
        PlayState play = GetComponent<PlayState>();
    }
    private void Update()
    {
        Disable();
        nextlevel();
    }
    public void nextlevel()
    {
        SceneManager.LoadScene(2);
    }
    public void Disable()
    {
        play.enabled = false;
    }
}
