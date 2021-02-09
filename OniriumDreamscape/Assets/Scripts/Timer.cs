using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timeSlider;
    public Text timerText;
    public float gameTime;
    public float actualTime;


    private bool stopTimer;

     void Start()
    {
        actualTime = gameTime;
        stopTimer = false;
        //timeSlider.maxValue = gameTime;
        //timeSlider.value = gameTime;
        
    }
     void Update()
    {
        
        timeSlider.maxValue = gameTime;
        timeSlider.value = actualTime;
        float time = gameTime - Time.time;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (time <=0)
        {
            stopTimer = true;
        }

        if (stopTimer == false)
        {
            timerText.text = textTime;
            timeSlider.value = time;
        }
    }

}
