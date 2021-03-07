using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float gameTime;
    public GameManager gameManagerSC;
    public Text timerText;

    private Light luzOso;       // Luz asociada el gameobject Oso
    public bool stopTimer;

    void Start()
    {        
        luzOso = FindObjectOfType<PlayerController>().transform.GetChild(0).transform.GetChild(2).GetComponent<Light>();
        gameManagerSC = FindObjectOfType<GameManager>();
        timerText = FindObjectOfType<Timer>().transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Text>();
        gameTime = 60;       
        stopTimer = false;

    }
     void Update()
    {
        float time = gameTime - Time.timeSinceLevelLoad;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        
        IntensidadMuerte(Time.timeSinceLevelLoad/gameTime);         //Con este metodo actualizamos de manera constante la intensidad de la luz 
                                                                    //correspondiente al tiempo que te queda para morir
        if (minutes == 0 && seconds == 0)
        {           
            stopTimer = true;         
            gameManagerSC.GameOver();         
            
        }

        if (stopTimer == false)
        {
            timerText.text = textTime;            
        }

    }
    void IntensidadMuerte(float n)
    {
        luzOso.intensity = Mathf.Lerp(1.4f, 0.3f, n);   //Interpola linealmente de un valor maximo a uno minimo en la magnitud n, este caso el temporizador.        
    }
   
}
