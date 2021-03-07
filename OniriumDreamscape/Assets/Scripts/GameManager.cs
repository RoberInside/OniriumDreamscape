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
        Cursor.visible = false; //Desactiva el cursor mientras se está jugando
        fundidoSC = FindObjectOfType<Fundido>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
        pantallaGameOverGO = FindObjectOfType<Timer>().transform.GetChild(0).transform.GetChild(7).gameObject;
    }

    public void GameOver() //Metodo Game Over
    {
        Cursor.visible = true; //Activa cursor
        pantallaGameOverGO.SetActive(true); //Activa pantalla Game Over 
        playerGO.SetActive(false); //Desactiva al jugador
        
    }
    public void SiguienteNivel()//Siguiente nivel mediante FadeOut
    {
        fundidoSC.FadeOut();       
    }
    void Update()
    {

    }
    public void RestartLevel() //reiniciar el nivel
    {
        Cursor.visible = false;
        Time.timeScale = 1;       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       
    }
}
