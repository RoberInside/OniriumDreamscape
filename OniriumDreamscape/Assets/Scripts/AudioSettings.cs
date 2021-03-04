using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour  //este script nos sirve para mantener los valores que se asignan en el audio manager en el resto de escenas
{
    private static readonly string gameMusicPref = "gameMusicPref"; 
    private static readonly string SFXPref = "SFXPref";
    private float gameMusicFloat, SFXFloat;
    public AudioSource[] BGMusicSounds;
    public AudioSource[] SFXSounds;

    private void Awake() //este método se usa para que en cuanto cargue la siguiente escena llame a la funcion de continue settings y pueda mantener los ajustes
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        gameMusicFloat = PlayerPrefs.GetFloat(gameMusicPref);  //este método nos sirve para mantener los ajustes del volumen que haya elegido el jugador en el main menu
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
    public void PlayPickUp() //para llamar al sonido del pickup
    {
        SFXSounds[0].loop = false;
        SFXSounds[0].Play();
    }
    public void PlayFrightmare() //para llamar al sonido de las frightmares
    {
        SFXSounds[1].loop = false;
        SFXSounds[1].Play();
    }

    public void PlayPortal()  //para llamar al sonido del portal
    {
        SFXSounds[2].loop = false;
        SFXSounds[2].Play();
    }
}
