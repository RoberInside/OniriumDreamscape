using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviles : MonoBehaviour
{
    public GameObject plataforma;
    public GameObject player;

    private void Start()
    {
        plataforma = GameObject.FindGameObjectWithTag("PlatformMovil");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        gameObject.transform.SetParent(gameObject.transform);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{

    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        other.gameObject.transform.parent = null;
    //    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}


