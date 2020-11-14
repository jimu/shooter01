﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    AudioSource audioSource;

    override protected void Init()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayOneShot(AudioClip sfx)
    {
        audioSource.PlayOneShot(sfx);
    }
}
