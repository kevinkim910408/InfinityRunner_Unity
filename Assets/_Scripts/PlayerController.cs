using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // keycodes
    KeyCode jump = KeyCode.Space;

    //components
    public GameManager gameManager;
    public Rigidbody rigid;
    Animator animator;

    [Header("Speed")]
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float speedMultiplier;
    [SerializeField] float speedIncreaseMilestone;
    [SerializeField] float speedMilestoneCount;
    [SerializeField] float moveSpeedStore;
    [SerializeField] float speedMilestoneCountStore;
    [SerializeField] float speedIncreaseMilestoneStore;

    [Header("Jump")]
    [SerializeField] float jumpForce = 5.0f;
    [SerializeField] float TrippleJumpForce = 10.0f;
    [SerializeField] float jumpTimeCount;
    [SerializeField] float jumpTime;
    [SerializeField] int jumpCount;

    // boolean
    private bool isJumpig = false;
    public bool isDead;

    // Particle
    [SerializeField] ParticleSystem jumpParticlePrefab;

    // Position
    [SerializeField] Transform jumpParticleSpawnPoint;
    ParticleSystem jumpParticle;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        jumpTimeCount = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
        animator = GetComponent<Animator>();

        isDead = false;
        jumpParticle = Instantiate(jumpParticlePrefab, jumpParticleSpawnPoint.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        Run();
        Jump();
    }


    public void Run()
    {
        if (!isDead)
        {
            if (transform.position.x > speedMilestoneCount)
            {
                speedMilestoneCount += speedIncreaseMilestone;
                speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
                moveSpeed = moveSpeed * speedMultiplier;

                // max speed
                if (moveSpeed > 15)
                {
                    moveSpeed = 15;
                }
            }

            rigid.velocity = new Vector3(moveSpeed, rigid.velocity.y, rigid.velocity.z);
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(jump))
        {
            jumpParticle.transform.position = jumpParticleSpawnPoint.transform.position;
            jumpParticle.transform.position = jumpParticleSpawnPoint.transform.position;

            animator.SetBool("isJump",true);

            jumpParticle.Play();
            // if on ground
            if (!isJumpig)
            {
                //rigid.velocity = new Vector3(rigid.velocity.x, jumpForce, rigid.velocity.z);
                rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isJumpig = true;
                jumpCount--;
            }
            else if (isJumpig && jumpCount > 0)
            {
                // rigid.velocity = new Vector3(rigid.velocity.x, jumpForce, rigid.velocity.z);
                rigid.AddForce(Vector3.up * TrippleJumpForce, ForceMode.Impulse);
                isJumpig = true;
                jumpCount--;
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
            jumpCount = 2;
            isJumpig = false;
            jumpTimeCount = jumpTime;
            animator.SetBool("isJump", false);
        }

        if (collision.gameObject.CompareTag("DeathPlane"))
        {
            moveSpeed = moveSpeedStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            speedMilestoneCount  = speedMilestoneCountStore;
            gameManager.LoseCondition();
        }
    }
}

