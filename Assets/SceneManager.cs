using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{

    public GameObject settings;

    private bool settingsActive = false;
    private bool ispressed;


    public void Start()
    {    
        AudioManager.Instance.PlayMusic(GameAssets.i.Music);
    }
    void Update()
    {

       // ENABLE OF SETTINGS
        if (Input.GetKeyDown("escape"))
        {
            AudioManager.Instance.PlaySFX(GameAssets.i.TransitionSfx);
            if (settingsActive == false && ispressed == false)
            {
                settings.SetActive(true);
                settingsActive = true;
                    ispressed = true;
             }

            if (settingsActive == true && ispressed == false)
            {
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
