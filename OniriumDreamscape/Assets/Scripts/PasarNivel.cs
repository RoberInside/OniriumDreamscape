﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasarNivel : MonoBehaviour
{
    public GameObject colliderPortal;
    public GameManager gameManagerSC;
    void Start()
    {
        colliderPortal = GameObject.Find("Portal");
        gameManagerSC = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManagerSC.SiguienteNivel();
        }

    }
    void Update()
    {
        
    }
}
