using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    //public Slider volumeSlider;
    public AudioSource gameMusic;
    private float musicVolume= 1f;
    // Start is called before the first frame update
    void Start()
    {
        //gameMusic = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        gameMusic.Play();
       // volumeSlider = GameObject.Find("slider volume").GetComponent<Slider>();
        musicVolume = PlayerPrefs.GetFloat("volume");
        gameMusic.volume = musicVolume;
       // volumeSlider.value = musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("volume", musicVolume);
        gameMusic.volume = musicVolume;
       // volumeSlider.value = musicVolume;
    }

     public void ChangeVolume(float volume)
    {
        musicVolume = volume;
    }

    
}
