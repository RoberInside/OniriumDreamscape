using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay ="First Play";
    private static readonly string gameMusicPref ="gameMusicPref";
    private static readonly string SFXPref ="SFXPref";
   
    private int firstPlayInt;
    public Slider gameMusicSlider, SFXSlider;
    private float gameMusicFloat, SFXFloat;
    public AudioSource[] BGMusicSounds;
    public AudioSource[] SFXSounds;

    void Start()
    {

             firstPlayInt = PlayerPrefs.GetInt(FirstPlay); //cuando el usuario juegue por primera vez se mostraran estos valores como default

             if (firstPlayInt == 0)
             {
                 gameMusicFloat = 1f;
                 SFXFloat = 1f;
                 gameMusicSlider.value = gameMusicFloat;
                 SFXSlider.value = SFXFloat;
                 PlayerPrefs.SetFloat(gameMusicPref, gameMusicFloat);
                 PlayerPrefs.SetFloat(SFXPref, SFXFloat);
                 PlayerPrefs.SetInt(FirstPlay, -1);

             }

        else
        {
            gameMusicFloat = PlayerPrefs.GetFloat(gameMusicPref);
            gameMusicSlider.value = gameMusicFloat;
            SFXFloat = PlayerPrefs.GetFloat(SFXPref);
            SFXSlider.value = SFXFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(gameMusicPref, gameMusicSlider.value);
        PlayerPrefs.SetFloat(SFXPref, SFXSlider.value);
    }

     void OnApplicationFocus(bool inFocus)
     {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
     }

    public void UpdateSound()
    {
        for (int i = 0; i < BGMusicSounds.Length; i++)
        {
            BGMusicSounds[i].volume = gameMusicSlider.value;
        }
        for (int i = 0; i < SFXSounds.Length; i++)
        {
            SFXSounds[i].volume = SFXSlider.value;
        }
    }


}
