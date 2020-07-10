using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSwitcher : MonoBehaviour
{
    public int CurrentMinigame { get; set; }
    //private in Minigame1Controller minigame1;
    //...
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentMinigame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //switch randomly between games
    }

    private void SwitchToMinigame (int n)
    {
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
