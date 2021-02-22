using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Fundido fundidoSC;
    public GameObject playerGO;
    
    void Start()
    {
        fundidoSC = FindObjectOfType<Fundido>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
    }

    public void GameOver()
    {
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
}
