using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_Menu : MonoBehaviour
{
    [SerializeField]
    public GameObject menuPausaGO;
   
    private void Start()
    {
        
    }

    void Update()
    {
        if (!menuPausaGO.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            menuPausaGO.SetActive(true);
            Time.timeScale = 0;
           
        }
        else if (menuPausaGO.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            menuPausaGO.SetActive(false);          
            Time.timeScale = 1;            
        }
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void ReanudarGame()
    {
        menuPausaGO.SetActive(false);
        Time.timeScale = 1;
    }

    public void MuteAudioManager()
    { }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;


    }
}
