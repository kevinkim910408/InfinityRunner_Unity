using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // components
    private CharacterController controller;


    [Header("Stats")]
    [SerializeField] float moveSpeed = 10.0f;

    private Vector3 moveVector = Vector3.zero;

    // Start is called before the first frame update
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
        // move left and right
        moveVector.x = Input.GetAxisRaw("Horizontal") * moveSpeed;


        // move up and down - jump


        // speed
        moveVector.z = moveSpeed;

        controller.Move(moveVector * Time.deltaTime);
    }
}
