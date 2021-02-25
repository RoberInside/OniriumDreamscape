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
        pantallaGameOverGO.SetActive(true);
        Cursor.visible = true;
        playerGO.SetActive(false);        
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
    }
    public void RestartLevel() //reiniciar el nivel
    {
        Time.timeScale = 1;
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }
}
