using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public float daño = 1; //Cantidad daño
    public AudioSettings audioManagerSC;

    private void Start()
    {
        audioManagerSC = FindObjectOfType<AudioSettings>();
    }
    private void OnTriggerEnter(Collider other) //Si el jugador entra en contacto con las frightmares 
    {
        if (this.CompareTag("Enemigo")) 
        {
            audioManagerSC.PlayFrightmare(); //Reproduce sonido de ataque
        }
        if (other.gameObject.GetComponent<SistemaVida>() != null) //Si la vida del jugador no esta a 0
        {
            other.gameObject.GetComponent<SistemaVida>().QuitarVida(daño); //Llama al metodo QuitarVida y le resta la cantidad de daño concreta.
        }
    }
}
