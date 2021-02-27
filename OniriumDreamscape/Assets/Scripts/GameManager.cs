using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Fundido fundidoSC;
    public GameObject playerGO;
    public GameObject pantallaGameOverGO;

    void Start()
    {
        fundidoSC = FindObjectOfType<Fundido>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
        pantallaGameOverGO = FindObjectOfType<Timer>().transform.GetChild(0).transform.GetChild(7).gameObject;
    }

    public void GameOver()
    {
        //Cursor.visible = true;
        pantallaGameOverGO.SetActive(true);
        playerGO.SetActive(false);
        Time.timeScale = 0;
    }
    public void SiguienteNivel()
    {
        fundidoSC.FadeOut();       
    }
    void Update()
    {
        if (Time.timeScale == 1)
        {
            Cursor.visible = false;
        }
        else if (Time.timeScale == 0) 
        {        
            Cursor.visible = true;
        }
    }
    public void RestartLevel() //reiniciar el nivel
    {
        Time.timeScale = 1;       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       
    }
}
