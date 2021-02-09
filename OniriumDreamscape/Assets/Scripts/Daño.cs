using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public float daño = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SistemaVida>() != null)
        {
            other.gameObject.GetComponent<SistemaVida>().QuitarVida(daño);
        }
    }
}
