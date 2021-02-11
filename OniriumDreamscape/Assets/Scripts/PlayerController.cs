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
    [SerializeField]
    private Camera _cam;

    private Rigidbody _playerRB;
    public LayerMask groundLayer;

    private float _horiMove, _vertMove, _jumpAxis;      
    private CapsuleCollider _collider;   

    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        _cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Eje de la camara
        Vector3 forward = _cam.transform.forward;
        Vector3 right = _cam.transform.right;

        forward.Normalize();
        right.Normalize();

        forward.y = 0;        

        _horiMove = Input.GetAxis("Horizontal");                                                    
        _vertMove = Input.GetAxis("Vertical");

        Vector3 movement = forward * _vertMove + right * _horiMove; 

                                                                                                             
        _playerRB.MovePosition(transform.position + movement * _speed * Time.fixedDeltaTime);

        //hace que el quaternion del jugador rote con la camara y con el eje de movimiento
        if (movement != new Vector3(0f,0f,0f))      // evita que se resetee la orientacion del Quaternion del jugador a 0,0,0 despues de rotar 
        {
            _playerRB.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), _rotSpeed));                                                  
        }

        if (Input.GetAxis("Jump") > 0.5 && IsGrounded())                                                        
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
