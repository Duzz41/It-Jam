using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
public AudioSource myFx;
public AudioClip hoverFx;
public AudioClip clickFx;

void Start()
{
    myFx = AudioManager.instance.sfxSource;
}

public void HoverSound()
{
    myFx.PlayOneShot(hoverFx);
}
public void ClickSound()
{
    myFx.PlayOneShot(clickFx);
}
}
