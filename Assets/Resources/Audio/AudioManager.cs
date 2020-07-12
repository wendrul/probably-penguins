using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned AudioManager", typeof(AudioManager)).GetComponent<AudioManager>();
                }
            }
            return (instance);
        }
        private set
        {
            instance = value;
        }
    }

    AudioMixer audioMixer;

    AudioMixerGroup[] audioMixGroup;

    private AudioSource musicSource;
    private AudioSource musicSource2;
    private AudioSource sfxSource;
    private bool firstMusicSourceIsPlaying = true;

    private void Awake()
    {
       audioMixer = Resources.Load<AudioMixer>("Master");

        DontDestroyOnLoad(this.gameObject);
        musicSource = this.gameObject.AddComponent<AudioSource>();
        musicSource2 = this.gameObject.AddComponent<AudioSource>();
        sfxSource = this.gameObject.AddComponent<AudioSource>();

        audioMixGroup = audioMixer.FindMatchingGroups("Master");

        musicSource.outputAudioMixerGroup = audioMixGroup[2];
        musicSource2.outputAudioMixerGroup = audioMixGroup[2];
        sfxSource.outputAudioMixerGroup = audioMixGroup[1];

        //loop music
        musicSource.loop = true;
        musicSource2.loop = true;
    }

    public void PlayMusic(AudioClip musicClip)
    {
    
        AudioSource activeSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2;
        
        activeSource.clip = musicClip;
        activeSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

    public void PlayMusicWithFade(AudioClip newClip, float transitionTime = 1.0f)
    {
        AudioSource activeSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2;
        StartCoroutine(UpdateMusicWithFade(activeSource, newClip, transitionTime));

    }

    //Fade music effect
    private IEnumerator UpdateMusicWithFade(AudioSource activeSource, AudioClip newClip , float transitionTime)
        {
        if (!activeSource.isPlaying)
            activeSource.Play();
        float t = 0.0f;
        //fade out
        for (t = 0; t < transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (1 - (t / transitionTime));
            yield return null;
        }

        activeSource.Stop();
        activeSource.clip = newClip;
        activeSource.Play();
        //fade in
        for (t = 0; t < transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (t / transitionTime);
            yield return null;
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        musicSource2.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
