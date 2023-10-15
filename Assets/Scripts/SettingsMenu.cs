using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider masterSlider;
    public void SetMasterVolume(float volume)
    {
        volume = masterSlider.value;
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)
    {
        volume = sfxSlider.value;
        audioMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
    }
    public void SetMusicVolume(float volume)
    {
        volume = musicSlider.value;
        audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
    }
}
