using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_Menu : MonoBehaviour
{
    public GameObject menuPausaGO;
    public bool active;
    private void Start()
    {
        //menuPausaGO = GameObject.Find("MenuPausa");
        active = menuPausaGO.activeSelf;
    }

    void Update()
    {
        if (!active && Input.GetKeyDown(KeyCode.Escape))
        {
            menuPausaGO.SetActive(true);
        }
        else if (active && Input.GetKeyDown(KeyCode.Escape))
        {
            menuPausaGO.SetActive(false);
        }
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
