using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayState : MonoBehaviour
{

    private void Awake()
    {
        this.enabled = true;
    }
    private void Start()
    {
        WinState win = GetComponent<WinState>();
        LoseState lose = GetComponent<LoseState>();
        DeathState dead = GetComponent<DeathState>();
        lose.enabled = false;
        win.enabled = false;
        dead.enabled = false;
    }

}
