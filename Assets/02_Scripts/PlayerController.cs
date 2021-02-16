using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //components
    public Rigidbody rigid;

    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float jumpForce = 5.0f;


    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigid.velocity = new Vector3(moveSpeed, rigid.velocity.y, rigid.velocity.z);
    }

}

