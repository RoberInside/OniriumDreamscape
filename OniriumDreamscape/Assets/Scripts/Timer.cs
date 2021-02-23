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
        actualTime = gameTime;
        stopTimer = false;
        luzOso = FindObjectOfType<PlayerController>().transform.GetChild(0).transform.GetChild(2).GetComponent<Light>();
        gameManagerSC = FindObjectOfType<GameManager>();

    }
     void Update()
    {
        


        float time = gameTime - Time.time;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        IntensidadMuerte(Time.time/gameTime);

        if (time <=0)
        {
            Muerte();
            stopTimer = true;
            
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
    public void Muerte()
    {
        gameManagerSC.GameOver();
    }
}
