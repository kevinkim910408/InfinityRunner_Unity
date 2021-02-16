using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // keycodes
    KeyCode jump = KeyCode.Space;

    //components
    public Rigidbody rigid;

    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float jumpForce = 5.0f;

    // boolean
    private bool isJumpig = false;


    // layer
    


    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Run();
        Jump();
    }


    public void Run()
    {
        rigid.velocity = new Vector3(moveSpeed, rigid.velocity.y, rigid.velocity.z);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(jump))
        {
            if (!isJumpig)
            {
                //rigid.velocity = new Vector3(rigid.velocity.x, jumpForce, rigid.velocity.z);
                rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isJumpig = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumpig = false;
        }
    }
}

