using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SetSfxVolume : MonoBehaviour
{

    public AudioMixer mixer;


    public void SetSfxValue(float sliderValue)
    {
        mixer.SetFloat("SfxVol", Mathf.Log10(sliderValue) * 20);
    }
}
