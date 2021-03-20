using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    // components
    PlayerController playerController;
    TimeManager timeManager;
    Animator animator;
    public int rand;

    // sounds
    AudioSource audioSource;
    [SerializeField] AudioClip speedUp = null;
    [SerializeField] AudioClip speedDown = null;
    [SerializeField] AudioClip timerUp = null;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        timeManager = FindObjectOfType<TimeManager>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rand = Random.Range(0, 5);
    }

    public void PlaySound(string action)
    {
        switch (action)
        {
            case "SPEEDUP":
                audioSource.clip = speedUp;
                break;
            case "SPEEDDOWN":
                audioSource.clip = speedDown;
                break;
            case "TIMERUP":
                audioSource.clip = timerUp;
                break;
        }
        audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // interaction anim;
            animator.SetBool("isInteracted", true);
            switch (rand)
            {
                // 40%
                case 0:
                case 1:
                    PlaySound("SPEEDDOWN");
                    playerController.moveSpeed -= 2.0f;
                    if(playerController.moveSpeed <= 5.0f)
                    {
                        playerController.moveSpeed = 5.0f;
                    }
                    Debug.Log("Speed Down");
                    break;

                    // 20%
                case 2:
                    PlaySound("SPEEDUP");
                    playerController.moveSpeed += 2.0f;
                    if (playerController.moveSpeed >= 15.0f)
                    {
                        playerController.moveSpeed = 15.0f;
                    }
                    Debug.Log("Speed Up");
                    break;

                  //  40%
                case 3:
                case 4:
                    PlaySound("TIMERUP");
                    timeManager.currentTime += 5.0f;
                    if(timeManager.currentTime > 60.0f)
                    {
                        timeManager.currentTime = 60.0f;
                    }
                    Debug.Log("Timer Up");
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine("DeactiveAnim");
        }
    }

    IEnumerator DeactiveAnim()
    {
        yield return new WaitForSeconds(2.0f);
        animator.SetBool("isInteracted", false);
    }
}
