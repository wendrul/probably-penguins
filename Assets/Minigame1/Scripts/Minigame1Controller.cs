using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1Controller : MonoBehaviour
{
    private bool playing;
    [SerializeField] private Player player;

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
        player.StoreMomentum();
    }

    public void Resume()
    {
        GameState.isPlaying = true;
        player.LoadMomentum();
    }
}
