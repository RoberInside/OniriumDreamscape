using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPausaGO;
    private MuteButton muteSC;
    private Fundido fundidoSC;
    private GameManager _gM;

   
    private void Start()
    {
        _gM = FindObjectOfType<GameManager>();
        fundidoSC = GetComponent<Fundido>();      
        muteSC = GetComponent<MuteButton>(); //acceder al sc de mutebutton para llamar al metodo de mute
    }

    void Update()
    {
        if (!menuPausaGO.activeSelf && Input.GetKeyDown(KeyCode.Escape)) //lee el estado del menu (false) y si presionan la tecla esc lo cambia a true y se activa el menu
        {

            menuPausaGO.SetActive(true);
            Time.timeScale = 0; //paramos el tiempo mientras esté activo el menú de pausa
           
        }
        
    }
    public void ReturnMainMenu() //Devolver al menú principal
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        fundidoSC.FadeOut();
    }

    public void ReanudarGame() //reanudar el juego, se desactiva el menu de pausa
    {
        Time.timeScale = 1;        
        menuPausaGO.SetActive(false);
    }


    public void RestartLevel() //reiniciar el nivel
    {
        _gM.RestartLevel();
        
    }
   
}
