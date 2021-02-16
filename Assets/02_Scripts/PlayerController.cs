using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // components
    private CharacterController controller;

    [Header("Stats")]
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float gravity = 9.8f;
    [SerializeField] float jumpForce = 5.0f;

    
    private float verticalVelocity = 0.0f;
    private Vector3 moveVector = Vector3.zero;

    // Initialize
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }


    public void PlayerMovement()
    {
        // give gravity, so keep feels heavy.
        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // move left and right
        moveVector.x = Input.GetAxisRaw("Horizontal") * moveSpeed;

        // speed
        moveVector.z = moveSpeed;


        controller.Move(moveVector * Time.deltaTime);
    }

}

