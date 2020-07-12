﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _i;
        }
    }

    public AudioClip Music;
    public AudioClip TransitionSfx;



    // Visual Novel SoundBank

    public AudioClip AshkanSwooshSfx;
    public AudioClip IranianClick;
    public AudioClip DesertBleu;
    public AudioClip donPinguiver;
    public AudioClip smerelo;
    public AudioClip approachingAsteroid;
    public AudioClip shipHitAsteroid;
    public AudioClip shieldBlockAsteroid;
    public AudioClip VisualNovelMusic;

    // MiniGame Smerelo
    public AudioClip SpaceCrashSFX;
    public AudioClip UFOEngineSFX;
    public AudioClip BlowtorchSFX;

    public AudioClip SnapBouz;
    public AudioClip TakePiecesfx;
    public AudioClip LevelComplete;

}
