using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_Menu : MonoBehaviour
{
    [SerializeField]
    public GameObject menuPausaGO;
    public MuteButton muteSC;
    public Fundido fundidoSC;
   
    private void Start()
    {
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
        else if (menuPausaGO.activeSelf && Input.GetKeyDown(KeyCode.Escape)) //lee el estado del menu (true) y si vuelven a presionar esc lo cambia a false y se desactiva
        {
            menuPausaGO.SetActive(false);          
            Time.timeScale = 1; //devolvemos el tiempo a su escala normal y se reanuda la partida desde donde se quedó           
        }
    }
    public void ReturnMainMenu() //Devolver al menú principal
    {
        SceneManager.LoadScene("MainMenu");
        fundidoSC.FadeOutMainMenu();
        Time.timeScale = 1;
    }

    public void ReanudarGame() //reanudar el juego, se desactiva el menu de pausa
    {
        menuPausaGO.SetActive(false);
        Time.timeScale = 1;
    }


    public void RestartLevel() //reiniciar el nivel
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
   
}
