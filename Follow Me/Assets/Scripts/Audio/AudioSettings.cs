﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    FMOD.Studio.EventInstance SFXVolumeTestEvent;

    FMOD.Studio.Bus Music;
    FMOD.Studio.Bus SFX;
    float MusicVolume = 0.5f;
    float SFXVolume = 0.5f;
  

    void Awake()
    {
        Music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        SFXVolumeTestEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/SFXVolumeTest");
    }

     void Update()
    {
        Music.setVolume(MusicVolume);
        SFX.setVolume(SFXVolume);
    }

    public void MusicVolumeLevel (float newMusicVolume)
    {
        MusicVolume = newMusicVolume;
    }

    public void SFXVolumeLevel (float newSFXVolume)
    {
        SFXVolume = newSFXVolume;

        FMOD.Studio.PLAYBACK_STATE PbState;
        SFXVolumeTestEvent.getPlaybackState(out PbState);
        if (PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            SFXVolumeTestEvent.start();
        }
    }
}