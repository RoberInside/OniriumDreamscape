using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public Fundido fundidoSC;  //declaramos el fundido para poder escontrarlo y usarlo a posteriori

    private void Start()
    {
        Cursor.visible = true; //esto sirve para que el cursor sí que sea visible en la escena del menú
        fundidoSC = FindObjectOfType<Fundido>().GetComponent<Fundido>();
    }
    public void PlayGame()  //llamamos al método fundido cuando le damos a jugar para que realice el fade out y haga el cambio de escena
    {
        fundidoSC.FadeOut(); 
    }
    public void QuitGame()
    {
        Application.Quit();  //esta línea nos cierra el juego 
    }
}
