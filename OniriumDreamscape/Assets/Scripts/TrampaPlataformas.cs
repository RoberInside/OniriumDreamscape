using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaPlataformas : MonoBehaviour
{
    public Rigidbody puasRB;
    [SerializeField,Range(0.0f,1.5f)]
    private float _tiempoCaida = 0.5f;
    private RigidbodyConstraints _constraint;
    void Start()
    {
        puasRB = GetComponentInChildren<Rigidbody>();
        _constraint = puasRB.constraints;

        puasRB.constraints = RigidbodyConstraints.FreezePositionY; //Congelamos la plataforma mediante el contraint de Y para evitar que se caiga la misma

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) //Al pasar por el trigger activa la corrutina del tiempo que falta para que caiga la plataforma
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TiempoCaida());
        }
        
    }
    
    IEnumerator TiempoCaida() //Una vez acabado el timpo de espera desactiva el constraint que evita que la plataforma de pinchos caiga sobre el jugador.
    {
        
        yield return new WaitForSeconds(_tiempoCaida);
        puasRB.constraints = _constraint;

    }
}
