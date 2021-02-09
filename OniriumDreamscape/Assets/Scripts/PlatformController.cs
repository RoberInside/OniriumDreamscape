using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Rigidbody _platformRB; //se declara el rigid body de la plataforma porque es lo que voy a mover
    public Transform[] _platformPositions; //se crea un array para almacenar las posiciones 
    public float _platformSpeed; // se crea un float para guardar la velocidad


    private int _actualPosition = 0;
    private int _nextPosition = 1;

    void Update()
    {
        MovePlatform();
    }
    void MovePlatform()
    {
        _platformRB.MovePosition(Vector3.MoveTowards(_platformRB.position, _platformPositions[_nextPosition].position, _platformSpeed * Time.deltaTime)); //se usa la funcion MoveTowards para mover la plataforma entre el punto a y el b


        if (Vector3.Distance(_platformRB.position, _platformPositions[_nextPosition].position) <= 0)
        {
            _actualPosition = _nextPosition;
            _nextPosition++;
        }

        if (_nextPosition > _platformPositions.Length -1)
        {
            _nextPosition = _actualPosition;
        }
    }
}
