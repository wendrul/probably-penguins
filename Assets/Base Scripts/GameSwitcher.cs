using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
    [SerializeField] private Book minigame3;
    [Header("Minigame Settings")]
    [Space]
    [SerializeField] private float roundTime;
    [SerializeField] private float[] roundTimeMin;
    [SerializeField] private float[] roundTimeMax;
    [SerializeField] private int maximumDifficulty;
    private bool paused;
    
    private float firstGameTimestamp = 0;
    private float secondGameTimestamp = 0;
    private float thirdGameTimestamp = 0;
    private float fourthGameTimestamp = 0;

    private int prevGame;
    private int activeGame;
    private int seriousCounter = 0;

    public int seriousMax;

    void Start()
    {
        activeGame = 0;
        CurrentMinigame = 1;
        elapsed = 0f;
        paused = false;
        currentMinigameDuration = Random.Range(roundTimeMin[CurrentMinigame], roundTimeMax[CurrentMinigame]);
        AudioManager.Instance.PlayMusic(GameAssets.i.donPinguiver);
        AudioManager.Instance.SetMusicVolume(0.01f);

       
        //temporal:
        SwitchToMinigame();
            

    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
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
            if (CurrentMinigame != 3 && elapsed > roundTime)
            {
                elapsed = 0f;
                SwitchToMinigame();
            }
            if (CurrentMinigame == 3 && minigame3.PageWasPlayed)
            {
                SwitchToMinigame();
                elapsed = 0;
            }
        }

    }

    private void SwitchToMinigame ()
    {
        seriousCounter++;
        prevGame = activeGame;
        while (prevGame == activeGame)
            activeGame = Random.Range(0, 2);
        if (seriousCounter >= seriousMax)
        {
            activeGame = 3;
            seriousCounter = 0;
        }
        if (Health.Instance.Difficulty < maximumDifficulty)
            Health.Instance.Difficulty++;
        penguins[CurrentMinigame].ResetTrigger("jump");
        penguins[CurrentMinigame].SetTrigger("rest");
        penguins[activeGame].ResetTrigger("rest");
        penguins[activeGame].SetTrigger("jump");
        switch (activeGame)
        {
            case 0:
                PauseCurrentGame();
                CurrentMinigame = 0;
                //sfx transition
                AudioManager.Instance.PlaySFX(GameAssets.i.TransitionSfx, 0.3f);
                //
                AudioManager.Instance.PlayMusicAtTime(GameAssets.i.donPinguiver, firstGameTimestamp % 27);
                minigame0.Resume();
                cameraHolder.position = cameraPositions[0].position;
                break;
            case 1:
                PauseCurrentGame();
                CurrentMinigame = 1;
                //sfx transition
                AudioManager.Instance.PlaySFX(GameAssets.i.TransitionSfx, 0.3f);
                //
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
                //sfx transition
                AudioManager.Instance.PlayMusicAtTime(GameAssets.i.VisualNovelMusic, thirdGameTimestamp % 53);
                minigame3.Resume();
                cameraHolder.position = cameraPositions[3].position;
                break;
            case 4:
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
                minigame3.PageWasPlayed = false;
                minigame3.Pause();
                break;
            case 4:
                break;
            default:
                break;
        }
    }

    public void Pause()
    {
        paused = true;
        if (CurrentMinigame != 3)
            PauseCurrentGame();
    }

    public void Resume()
    {
        paused = false;
        switch (CurrentMinigame)
        {
            case 0:
                minigame0.Resume();
                break;
            case 1:
                minigame1.Resume();
                break;
            case 2:
                break;
            case 3:
                minigame3.Resume();
                break;
            case 5:
                break;
            default:
                break;
        }
    }

    public void GameOver()
    {
        Pause();
        cameraHolder.position = cameraPositions[4].position;
    }
}
