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

        puasRB.constraints = RigidbodyConstraints.FreezePositionY;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TiempoCaida());
        }
        
    }
    
    IEnumerator TiempoCaida()
    {
        
        yield return new WaitForSeconds(_tiempoCaida);
        puasRB.constraints = _constraint;

    }
}
