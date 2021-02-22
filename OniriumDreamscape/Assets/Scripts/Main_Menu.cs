using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public Fundido fundidoSC;

    private void Start()
    {
        Cursor.visible = true;
        fundidoSC = FindObjectOfType<Fundido>().GetComponent<Fundido>();
    }
    public void PlayGame()
    {
        fundidoSC.FadeOut();
        //SceneManager.LoadScene("Nivel 1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
