using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPersist : MonoBehaviour
{
    public static MusicPersist instance;

    public AudioSource[] soundEffects;

    void Awake()
    {
        if (instance != null)
        Destroy(gameObject);

        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
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
