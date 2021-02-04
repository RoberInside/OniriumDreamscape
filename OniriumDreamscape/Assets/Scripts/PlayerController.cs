using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float horiMove;
    public float vertMove;
    public float speed;
    public float jump;
    public bool isGrounded;
    public Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horiMove = Input.GetAxis("Horizontal");
        vertMove = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horiMove, 0, vertMove) * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            jump = 40;
            playerRB.AddForce(new Vector3(0, jump * speed, 0));
            
            //transform.Translate(new Vector3(0, jump, 0) * Time.deltaTime);
        }
        
    }
  
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
            jump = 0;
        }
    }

}
