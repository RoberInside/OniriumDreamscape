﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public Fundido fundidoSC;
    
    private void Start()
    {          
        fundidoSC = FindObjectOfType<Fundido>();
    }
    public void PlayGame()
    {
        fundidoSC.FadeOut();
       
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
