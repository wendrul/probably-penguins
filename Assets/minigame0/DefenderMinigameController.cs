﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderMinigameController : MonoBehaviour
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

    public void Pause ()
    {
        playing = false;
    }

    public void Resume ()
    {
        playing = true;
    }
}
