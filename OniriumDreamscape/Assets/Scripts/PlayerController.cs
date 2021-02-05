using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField, Range(0, 0.5f)]
    private float distanceToGround = 0.1f;

    public Rigidbody playerRB;
    public LayerMask groundLayer;

    private float _horiMove, _vertMove, _jumpAxis;    
    private float _speed;
    private float _jumpForce;
    private CapsuleCollider _collider;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        _speed = 5;
        _jumpForce = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _horiMove = Input.GetAxis("Horizontal") * 5;
        _vertMove = Input.GetAxis("Vertical");
        _jumpAxis = Input.GetAxis("Jump");

        Quaternion angleRot = Quaternion.Euler(Vector3.up * _horiMove * Time.fixedDeltaTime);

        playerRB.MovePosition(transform.position + transform.forward * _vertMove * Time.fixedDeltaTime);
        playerRB.MoveRotation(angleRot * playerRB.rotation);

        if (Input.GetAxis("Jump") > 0.5 && IsGrounded())
        {
            Debug.Log(Input.GetAxis("Jump"));
            playerRB.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
        
        
    }
    bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);
        bool isGrounded = Physics.CheckCapsule(_collider.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);        
        return isGrounded;
    }



}
