﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;


	//2 different audio channels that both go through the master channel
	public void SetMasterVolume (float masterVolume)
    {
        audioMixer.SetFloat("masterVolume", masterVolume);

    }

    public void SetMusicVolume(float musicVolume)
    {
        audioMixer.SetFloat("musicVolume", musicVolume);

    }

    public void SetSFXVolume(float sFXVolume)
    {
        audioMixer.SetFloat("sFXVolume", sFXVolume);

    }
}
