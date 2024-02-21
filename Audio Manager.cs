using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [Header("Audio Source")] public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clip")] public AudioClip click;
    public AudioClip gameOver;
    public AudioClip destroy;
    public AudioClip backGround;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        musicSource.clip = backGround;
        musicSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
