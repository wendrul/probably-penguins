using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderMinigameController : MonoBehaviour
{
    private bool playing;
    private AsteroidLauncher asteroidLauncher;

    [SerializeField]private MouseShield mouse;
    
    void Start()
    {
        asteroidLauncher = GetComponent<AsteroidLauncher>();
    }

    void Update()
    {
        if (playing)
        {
            mouse.Loop();
            asteroidLauncher.Loop();
        }
    }

    public void Pause ()
    {
        playing = false;
        mouse.Pause();
    }

    public void Resume ()
    {
        playing = true;
        mouse.Resume();
    }
}
