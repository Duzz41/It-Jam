using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundSettings : MonoBehaviour
{
    public static SoundSettings instance;
    public Slider musicSlider;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetVolume(float volume)
    {
        AudioManager.instance.MusicVolume(volume);
        AudioManager.instance.SFXVolume(volume);
    }

    public void OpenSlider()
    {
        if (musicSlider.gameObject.activeSelf == false)
            musicSlider.gameObject.SetActive(true);
        else
            musicSlider.gameObject.SetActive(false);
    }
}
