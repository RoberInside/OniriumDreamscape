using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay ="First Play";
    private static readonly string gameMusicPref ="gameMusicPref"; // declaramos variables de lecturas para almacenar los estados/preferencias del jugador
    private static readonly string SFXPref ="SFXPref";
   
    private int firstPlayInt;
    public Slider gameMusicSlider, SFXSlider; //declaramos los sliders y los float de los que serán sus valores
    private float gameMusicFloat, SFXFloat;
    public AudioSource[] BGMusicSounds; //en los arrays almacenamos todos los sonidos del juego
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
                 PlayerPrefs.SetFloat(gameMusicPref, gameMusicFloat);  //aquí guardamos los valores default y le indicamos que después de ese first play los demás ya no lo son
                 PlayerPrefs.SetFloat(SFXPref, SFXFloat);
                 PlayerPrefs.SetInt(FirstPlay, -1);

             }

        else
        {
            gameMusicFloat = PlayerPrefs.GetFloat(gameMusicPref); // aquí le decimos que si ya no es la primera jugada, recoja los valores que indique el usuario
            gameMusicSlider.value = gameMusicFloat;
            SFXFloat = PlayerPrefs.GetFloat(SFXPref);
            SFXSlider.value = SFXFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(gameMusicPref, gameMusicSlider.value); //este método nos sirve para guardar esos valores o preferencias que nos ha indicado el jugador. salta error en el edito, como si no recogiera las preferencias del jugador, pero sí que lo hace siempre
        PlayerPrefs.SetFloat(SFXPref, SFXSlider.value);
    }

     void OnApplicationFocus(bool inFocus)
     {
        if (!inFocus)
        {
            SaveSoundSettings();   //este método nos sirve para que cuando el jugador salga del juego, se guarden los ajustes que él ha elegido
        }
     }

    public void UpdateSound() //este método nos sirve para para actualizar todos los sonidos que aparezcan en el juego, que todos los elementos del array recojan ese mismo valor
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
