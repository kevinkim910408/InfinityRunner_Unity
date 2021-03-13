using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePatrol : MonoBehaviour
{
    Rigidbody rigid;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovingFront();
    }

    private void MovingFront()
    {
        rigid.velocity = new Vector3(-moveSpeed, rigid.velocity.y, rigid.velocity.z);
    }
}
