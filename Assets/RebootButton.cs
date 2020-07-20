using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RebootButton : MonoBehaviour
{
    public void RebootGame()
    {
            AudioManager.Instance.SetMusicVolume(0f);
            SceneManager.LoadScene(0);
    }
}
