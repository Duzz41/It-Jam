using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource, backgroundSource, chaseSource;
    public GameObject player;

    // public FirstPersonController FPController;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        PlayMusic("Theme");
        MusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
        SFXVolume(PlayerPrefs.GetFloat("SFXVolume"));
    }
    void Update()
    {
        FindObject();
    }
    public void FindObject()
    {
        if (SceneManager.GetActiveScene().name == "Forest2")
        {

            player = GameObject.FindGameObjectWithTag("Player");
        }
    }



    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
        }
        else
        {
            musicSource.clip = s.clip[0];
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
        }
        else
        {
            backgroundSource.spatialBlend = 0f;
            backgroundSource.clip = s.clip[UnityEngine.Random.Range(0, s.clip.Count)];
            backgroundSource.Play();
        }
    }
    public void PlayChase(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
        }
        else
        {
            chaseSource.spatialBlend = 0f;
            chaseSource.clip = s.clip[UnityEngine.Random.Range(0, s.clip.Count)];
            chaseSource.Play();
        }
    }

    public void PlaySFXOneShot(string name)
    {

        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
        }
        else
        {

            sfxSource.gameObject.transform.position = player.transform.position;
            sfxSource.spatialBlend = 1f;
            sfxSource.clip = s.clip[0];
            sfxSource.PlayOneShot(sfxSource.clip);

        }
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
        chaseSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
        backgroundSource.volume = volume;
    }
}
