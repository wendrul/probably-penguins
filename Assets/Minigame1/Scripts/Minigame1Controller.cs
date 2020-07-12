using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1Controller : MonoBehaviour
{
    private bool playing;
    [SerializeField] private Player player;
    [SerializeField] private AsteroidShooter asteroidShooter;
    

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
        asteroidShooter.StopShooting();
        player.StoreMomentum();
    }

    public void Resume()
    {
        GameState.isPlaying = true;
        asteroidShooter.StartShooting();
        player.LoadMomentum();
    }
}
