using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karonte : MonoBehaviour
{
    public GameObject particleEffect;
     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Efecto();
        }
    }
    void Efecto()
    {
        Instantiate(particleEffect, transform.position, transform.rotation);
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
