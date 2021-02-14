using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Rigidbody _platformRB; //se declara el rigid body de la plataforma porque es lo que voy a mover
    public Transform[] _platformPositions; //se crea un array para almacenar las posiciones 
    public float _platformSpeed; // se crea un float para guardar la velocidad


    private int _actualPosition= 0;
    private int _nextPosition = 1;

    private bool _moveNext = true;
    
    void FixedUpdate()
    {
        MovePlatform();
    }

    
    void MovePlatform()
    {

        if (_moveNext)
        {
            StopCoroutine(WaitMove());
          _platformRB.MovePosition(Vector3.MoveTowards(_platformRB.position, _platformPositions[_nextPosition].position, _platformSpeed * Time.deltaTime)); //se usa la funcion MoveTowards para mover la plataforma entre el punto a y el b
        }


        if (Vector3.Distance(_platformRB.position, _platformPositions[_nextPosition].position) <= 0)
        {
            StartCoroutine(WaitMove());
            _actualPosition = _nextPosition;
            _nextPosition++;

            if (_nextPosition > _platformPositions.Length -1)
            {
                _nextPosition = 0;
            }
        }

    }

    IEnumerator WaitMove()
    {
        _moveNext = false;
        yield return new WaitForSeconds(0.3f);
        _moveNext = true;
    }
}
