using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimaciones : MonoBehaviour
{
    Animator animThayne;
    // Start is called before the first frame update
    void Awake()
    {
        animThayne = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool correr = Input.GetKey(KeyCode.W); //Al presionar W,A,S,D se activa la animacion de correr En la direccion indicada en el animation controller
        animThayne.SetBool("Correr", correr);

        bool izq = Input.GetKey(KeyCode.A);
        animThayne.SetBool("Izq", izq);

        bool der = Input.GetKey(KeyCode.D);
        animThayne.SetBool("Der", der);

        bool atras = Input.GetKey(KeyCode.S);
        animThayne.SetBool("Atras", atras);

        if (Input.GetKeyDown(KeyCode.Space)) //Al pulsar espacio se activa la animacion de saltar desde el animation controller 
        {
            animThayne.SetTrigger("Salto");
        }
    }
}
