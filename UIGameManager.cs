using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameManager : MonoBehaviour
{
    public GameObject endgamepopup;
    public Text hptext;
    public Text scoretext;
    public Text scorefinal;
    public GameObject settingPopUp;
    public Slider SFXSlider;
    public Slider musicSlider;
    public AudioMixer mixer;
    private float value;

    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
        AudioManager.instance.PlaySFX(AudioManager.instance.click);
        AudioManager.instance.musicSource.Stop();
    }

    public void QuitGame()
    {
        Application.Quit();
        AudioManager.instance.PlaySFX(AudioManager.instance.click);
    }

    public void BackHome()
    {
        SceneManager.LoadScene("Home");
        AudioManager.instance.PlaySFX(AudioManager.instance.click);
        Time.timeScale = 1;
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene("GamePlay");
        AudioManager.instance.PlaySFX(AudioManager.instance.click);
        Time.timeScale = 1;
    }

    public void SettingPopUpTurnOn()
    {
        settingPopUp.SetActive(true);
        AudioManager.instance.PlaySFX(AudioManager.instance.click);
    }

    public void SettingPopUpTurnOff()
    {
        settingPopUp.SetActive(false);
        AudioManager.instance.PlaySFX(AudioManager.instance.click);
    }
    
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("Music", volume);
        PlayerPrefs.SetFloat("Music Volume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        mixer.SetFloat("SFX", volume);
        PlayerPrefs.SetFloat("SFX Volume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Music Volume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFX Volume");
    }
}