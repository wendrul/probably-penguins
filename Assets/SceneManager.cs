using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{

    public GameObject settings;
    [SerializeField] private GameSwitcher switcher;

    private bool settingsActive = false;
    private bool ispressed;


    public void Start()
    {    
        AudioManager.Instance.PlayMusic(GameAssets.i.DesertBleu);
        AudioManager.Instance.SetMusicVolume(0.35f);
    }
    void Update()
    {

       // ENABLE OF SETTINGS
        if (Input.GetKeyDown("escape"))
        {
            if (settingsActive == false && ispressed == false)
            {
                switcher.Pause();
                settings.SetActive(true);
                settingsActive = true;
                    ispressed = true;
             }

            if (settingsActive == true && ispressed == false)
            {
                switcher.Resume();
                Debug.Log("hir");
                settings.SetActive(false);
                settingsActive = false;
                    ispressed = true;
            }
        }
        if (Input.GetKeyUp("escape"))
        {
            ispressed = false;
        }
        //
    }
}
