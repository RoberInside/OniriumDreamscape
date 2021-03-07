using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suelo : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        
        if (other.gameObject.GetComponent<SistemaVida>() != null)
        {
            StartCoroutine(TiempoInmortal());


            other.gameObject.GetComponent<SistemaVida>().QuitarVida(3); //Al haber subido el daño al numero maximo de vidas y entrar en contacto con el collider del "suelo" se realiza una instakill
        }
    }
    IEnumerator TiempoInmortal()
    {
        
        yield return new WaitForSeconds(2f);
        
    }
}
