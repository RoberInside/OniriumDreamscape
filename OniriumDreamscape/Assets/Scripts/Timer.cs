using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float gameTime;
    public float actualTime;
    public Light luzOso;
    public float intensidadFinal;

    private bool stopTimer;
    public GameManager gameManagerSC;

    void Start()
    {
        
        gameTime = 60;
        actualTime = gameTime;
        stopTimer = false;
        luzOso = FindObjectOfType<PlayerController>().transform.GetChild(0).transform.GetChild(2).GetComponent<Light>();
        gameManagerSC = FindObjectOfType<GameManager>();

    }
     void Update()
    {
        float time = gameTime - Time.timeSinceLevelLoad;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        
        IntensidadMuerte(Time.timeSinceLevelLoad/gameTime);

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
        luzOso.intensity = Mathf.Lerp(1.4f, 0.3f, n);        
    }
   
}
