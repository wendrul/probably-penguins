using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMan : MonoBehaviour
{

    public GameObject settings;

    private bool settingsActive;

    private bool ispressed;

    public void Start()
    {
        
    }
    void Update()
    {
       // ENABLE OF SETTINGS
        if (Input.GetKeyDown("escape"))
        {
            if (settingsActive == false && ispressed == false)
            {
                //activate Pause here
                settings.SetActive(true);
                settingsActive = true;
                    ispressed = true;
             }

            if (settingsActive == true && ispressed == false)
            {
                // activate Resume here
                settings.SetActive(false);
                settingsActive = false;
                    ispressed = true;
            }
        }
        if (Input.GetKeyUp("escape"))
        {
            ispressed = false;
        }
    }
}
