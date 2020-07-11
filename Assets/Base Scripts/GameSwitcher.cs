using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSwitcher : MonoBehaviour
{
    public int CurrentMinigame { get; set; }
    private float elapsed;
    private float currentMinigameDuration;

    [Header("Animations")]
    [Space]
    [SerializeField] private Animator[] penguins;

    [Header("Minigames")]
    [Space]
    [SerializeField] private DefenderMinigameController minigame0;
    [Space]
    [SerializeField] private float[] roundTimeMin;
    [SerializeField] private float[] roundTimeMax;
    //private in Minigame1Controller minigame1;
    //...

    // Start is called before the first frame update
    void Start()
    {
        CurrentMinigame = 0;
        elapsed = 0f;
        currentMinigameDuration = Random.Range(roundTimeMin[CurrentMinigame], roundTimeMax[CurrentMinigame]);
        AudioManager.Instance.PlayMusic(GameAssets.i.donPinguiver);
        AudioManager.Instance.SetMusicVolume(0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
    }

    private void SwitchToMinigame (int n)
    {
        penguins[n].SetTrigger("jump");
        penguins[CurrentMinigame].SetTrigger("rest");
        switch (n)
        {
            case 0:
                PauseCurrentGame();
                //play game 0...
                break;
            case 1:
                PauseCurrentGame();
                break;
            case 2:
                PauseCurrentGame();
                break;
            case 3:
                PauseCurrentGame();
                break;
            case 5:
                PauseCurrentGame();
                break;
            default:
                Debug.Log("Minigame number what?");
                break;
        }
    }

    private void PauseCurrentGame()
    {
        switch (CurrentMinigame)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 5:
                break;
            default:
                Debug.Log("Minigame number what?");
                break;
        }
    }
}
