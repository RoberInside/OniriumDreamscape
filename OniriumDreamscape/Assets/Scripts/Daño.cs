using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public float daño = 1;
    public AudioSettings audioManagerSC;

    private void Start()
    {
        audioManagerSC = FindObjectOfType<AudioSettings>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Enemigo"))
        {
            audioManagerSC.PlayFrightmare();
        }
        if (other.gameObject.GetComponent<SistemaVida>() != null)
        {
            other.gameObject.GetComponent<SistemaVida>().QuitarVida(daño);
        }
    }
}
