using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karonte : MonoBehaviour
{
    public GameObject particleEffect;
     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //Al entrar en contacto con el trigger al rededor del gato va al metodo efecto
        {
            Efecto();
        }
    }
    void Efecto()
    {
        Instantiate(particleEffect, transform.position, transform.rotation); //Realiza una instancia del efecto y destruye el objeto
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
