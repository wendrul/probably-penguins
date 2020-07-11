using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1Controller : MonoBehaviour
{
    private bool playing;

    void Start()
    {

    }

    void Update()
    {
        if (playing)
        {

        }
    }

    public void Pause()
    {
        GameState.isPlaying = false;
    }

    public void Resume()
    {
        GameState.isPlaying = true;
    }
}
