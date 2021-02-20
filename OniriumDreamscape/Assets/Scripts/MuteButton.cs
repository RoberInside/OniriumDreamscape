using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour
{
    private bool _isMuted;
    // Start is called before the first frame update
    void Start()
    {
        _isMuted = false; //le damos el valor false desde el principio pq la musica está activa
    }

    public void MutePressed()
    {
        _isMuted = !_isMuted;
        AudioListener.pause = _isMuted; //si presiona el boton el booleano pasa a ser true y se pausa el audiolistener

    }
}
