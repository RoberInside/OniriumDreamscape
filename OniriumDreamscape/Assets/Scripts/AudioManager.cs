using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    //private static readonly string FirstPlay ="First Play";
    //private static readonly string gameMusicPref = "gameMusicPref";
    //private static readonly string SFXPref = "SFXPref";
    //private int firstPlayInt;
    public Slider gameMusicSlider, SFXSlider;
    private float gameMusicFloat, SFXFloat;
    public AudioSource gameSoundsAS;
    public AudioClip[] gameMusicAudio;
    public AudioClip[] SFXAudio;
    //private float musicVol = 1f;

    void Start()
    {
        gameMusicSlider.value = PlayerPrefs.GetFloat("volume");
    }

    

   //void Start()
   //{
   //     //firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

   //     if (firstPlayInt == 0)
   //     {
   //         gameMusicFloat = 1f;
   //         SFXFloat = 1f;
   //         gameMusicSlider.value = gameMusicFloat;
   //         SFXSlider.value = SFXFloat;
   //         PlayerPrefs.SetFloat(gameMusicPref, gameMusicFloat);
   //         PlayerPrefs.SetFloat(gameMusicPref, gameMusicFloat);
   //         //PlayerPrefs.SetInt(FirstPlay, -1);

   //     }

   //     else
   //     {
   //        gameMusicFloat = PlayerPrefs.GetFloat(gameMusicPref);
   //        gameMusicSlider.value = gameMusicFloat;
   //        SFXFloat = PlayerPrefs.GetFloat(SFXPref);
   //        SFXSlider.value = SFXFloat;
   //     }

   //}
   //public void SaveSoundSettings()
   //{
   //    PlayerPrefs.SetFloat(gameMusicPref, gameMusicSlider.value);
   //    PlayerPrefs.SetFloat(SFXPref, SFXSlider.value);
   //}

   // private void OnApplicationFocus(bool inFocus)
   // {
   //     SaveSoundSettings();
   // }

   // public void UpdateSound()
   // {
   //     for (int i = 0; i < gameMusicAudio.Length; i++)
   //     {
   //         gameMusicAudio[i].volume = gameMusicSlider.value;
   //     }

   //     for (int i = 0; i < SFXAudio.Length; i++)
   //     {
   //         SFXAudio[i].volume = SFXSlider.value;
   //     }
   // }

}
