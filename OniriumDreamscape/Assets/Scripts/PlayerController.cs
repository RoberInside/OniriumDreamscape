using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(0, 100)]
    private float _speed;
    [SerializeField, Range(0, 100)]
    private float _rotSpeed;
    [SerializeField, Range(0, 100)]
    private float _jumpForce;
    [SerializeField, Range(0, 0.5f)]
    private float distanceToGround = 0.1f;

    private Rigidbody _playerRB;
    public LayerMask groundLayer;

    private float _horiMove, _vertMove, _jumpAxis;      
    private CapsuleCollider _collider;   

    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _horiMove = Input.GetAxis("Horizontal") * _rotSpeed;            //se multiplica el eje por la magnitud de la fuerza correspondiente 
        _vertMove = Input.GetAxis("Vertical") * _speed;        

        Quaternion angleRot = Quaternion.Euler(Vector3.up * _horiMove * Time.fixedDeltaTime);       //se saca el quaternion convertido de un 
                                                                                                    //euler angles para calcular el angulo de rotacion mas la fuerza que se aplica para dicha rotacion por el tiempo fixed del update
        _playerRB.MovePosition(transform.position + transform.forward * _vertMove * Time.fixedDeltaTime);    //se suma al transform de la posicion la fuerza aplicada en el eje tomado segun el fixed delta time
        _playerRB.MoveRotation(angleRot * _playerRB.rotation);            //se multiplica el angulo de rotacion con la rotacion actual del objeto fisico siendo esta constante        

        if (Input.GetAxis("Jump") > 0.5 && IsGrounded())        // fuerza de impulso asociada al eje de salto si sobrepasa cierto umbral del input para que no se "acumulen" saltos y si solo si esta en el suelo
        {
            //Debug.Log(Input.GetAxis("Jump").ToString());
            _playerRB.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }        
        
    }
    /// <summary>
    /// Se detecta si el punto del capsule collider mas proximo al limite inferior del mismo esta en contacto con la layer correspondiente.
    /// (Solo para Capsule collider)
    /// </summary>
    /// <returns>true: Si esta en contacto con el suelo</returns>
    bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);
        bool isGrounded = Physics.CheckCapsule(_collider.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);        
        return isGrounded;
    }



}
