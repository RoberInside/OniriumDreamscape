using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private static readonly string gameMusicPref = "gameMusicPref";
    private static readonly string SFXPref = "SFXPref";
    private float gameMusicFloat, SFXFloat;
    public AudioSource[] BGMusicSounds;
    public AudioSource[] SFXSounds;

    private void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        gameMusicFloat = PlayerPrefs.GetFloat(gameMusicPref);
        SFXFloat = PlayerPrefs.GetFloat(SFXPref);

        for (int i = 0; i < BGMusicSounds.Length; i++)
        {
            BGMusicSounds[i].volume = gameMusicFloat;
        }
        for (int i = 0; i < SFXSounds.Length; i++)
        {
            SFXSounds[i].volume = SFXFloat ;
        }
    }
    public void PlayPickUp()
    {
        SFXSounds[0].loop = false;
        SFXSounds[0].Play();
    }
    public void PlayFrightmare()
    {
        SFXSounds[1].loop = false;
        SFXSounds[1].Play();
    }
}
