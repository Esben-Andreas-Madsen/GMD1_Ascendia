using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource[] soundEffects;
    private bool isMuted;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            UnityEngine.Debug.Log("AudioManager instance created.");
        }
        else
        {
            UnityEngine.Debug.Log("Destroying duplicate AudioManager instance.");
            Destroy(gameObject);
        }

    }

    public void PlaySound(int index)
    {
        if (index >= 0 && index < soundEffects.Length)
        {
            soundEffects[index].Play();
        }
    }

    public void SetVolume(float volume)
    {
        foreach (var audioSource in soundEffects)
        {
            audioSource.volume = volume;
        }
    }

    public void SetMute(bool isMuted)
    {
        foreach (var audioSource in soundEffects)
        {
            audioSource.mute = isMuted;
        }
    }
}
