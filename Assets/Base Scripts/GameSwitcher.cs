﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSwitcher : MonoBehaviour
{
    public int CurrentMinigame { get; set; }
    private float elapsed;
    private float currentMinigameDuration;

    [SerializeField] private Transform cameraHolder;
    [SerializeField] private Transform[] cameraPositions;

    [Header("Animations")]
    [Space]
    [SerializeField] private Animator[] penguins;

    [Header("Minigames")]
    [Space]
    [SerializeField] private DefenderMinigameController minigame0;
    [SerializeField] private Minigame1Controller minigame1;
    [Space]
    [SerializeField] private float roundTime;
    [SerializeField] private float[] roundTimeMin;
    [SerializeField] private float[] roundTimeMax;
    private float firstGameTimestamp = 0;
    private float secondGameTimestamp = 0;
    private float thirdGameTimestamp = 0;
    private float fourthGameTimestamp = 0;

    //private in Minigame1Controller minigame1;
    //...

    // Start is called before the first frame update
    void Start()
    {
        CurrentMinigame = 1;
        elapsed = 0f;
        currentMinigameDuration = Random.Range(roundTimeMin[CurrentMinigame], roundTimeMax[CurrentMinigame]);
        AudioManager.Instance.PlayMusic(GameAssets.i.donPinguiver);
        AudioManager.Instance.SetMusicVolume(0.01f);

       
        //temporal:
        if (CurrentMinigame == 0)
                SwitchToMinigame(1);
            else
                SwitchToMinigame(0);

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (CurrentMinigame == 0)
            firstGameTimestamp += elapsed;
        if (CurrentMinigame == 1)
            secondGameTimestamp += elapsed;
        if (CurrentMinigame == 2)
            thirdGameTimestamp += elapsed;
        if (CurrentMinigame == 4)
            fourthGameTimestamp += elapsed;
        if (elapsed > roundTime)
        {
            elapsed = 0f;

            //temporal: 
            if (CurrentMinigame == 0)
                SwitchToMinigame(1);
            else
                SwitchToMinigame(0);
        }

    }

    private void SwitchToMinigame (int n)
    {
        penguins[CurrentMinigame].ResetTrigger("jump");
        penguins[CurrentMinigame].SetTrigger("rest");
        penguins[n].ResetTrigger("rest");
        penguins[n].SetTrigger("jump");
        switch (n)
        {
            case 0:
                PauseCurrentGame();
                CurrentMinigame = 0;
                AudioManager.Instance.PlayMusicAtTime(GameAssets.i.donPinguiver, firstGameTimestamp % 27);
                minigame0.Resume();
                cameraHolder.position = cameraPositions[0].position;
                //play game 0...
                break;
            case 1:
                PauseCurrentGame();
                CurrentMinigame = 1;
                AudioManager.Instance.PlayMusicAtTime(GameAssets.i.smerelo, secondGameTimestamp % 59);
                minigame1.Resume();
                cameraHolder.position = cameraPositions[1].position;
                break;
            case 2:
                PauseCurrentGame();
                CurrentMinigame = 2;
                break;
            case 3:
                PauseCurrentGame();
                CurrentMinigame = 3;
                break;
            case 5:
                PauseCurrentGame();
                CurrentMinigame = 4;
                break;
            default:
                break;
        }
    }

    private void PauseCurrentGame()
    {
        switch (CurrentMinigame)
        {
            case 0:
                minigame0.Pause();
                break;
            case 1:
                minigame1.Pause();
                break;
            case 2:
                break;
            case 3:
                break;
            case 5:
                break;
            default:
                break;
        }
    }
}
