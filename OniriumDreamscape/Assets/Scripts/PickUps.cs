using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public Timer timerSC;
    public float vida = 1;

     void Start()
    {
        timerSC = FindObjectOfType<Timer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SistemaVida>() != null)
        {
            other.gameObject.GetComponent<SistemaVida>().DarVida(vida);
            timerSC.gameTime += 60;
            
        }
    }
}
