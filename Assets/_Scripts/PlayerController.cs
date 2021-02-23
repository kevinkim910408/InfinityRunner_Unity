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
    [SerializeField] float jumpTimeCount;
    [SerializeField] float jumpTime;

    // boolean
    private bool isJumpig = false;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        jumpTimeCount = jumpTime;
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
        if (Input.GetKeyDown(jump))
        {
            if(jumpTimeCount > 0)
            {
                rigid.velocity = new Vector3(rigid.velocity.x, jumpForce, 0);
                jumpTimeCount -= Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(jump))
        {
            jumpTimeCount = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumpig = false;
            jumpTimeCount = jumpTime;
        }
    }
}

