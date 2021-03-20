using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    PlayerController playerController;
    TimeManager timeManager;
    public int rand;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        timeManager = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        rand = Random.Range(0, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.CompareTag("Player"))
        {
            switch (rand)
            {
                // 40%
                case 0:
                case 1:
                    playerController.moveSpeed -= 2.0f;
                    if(playerController.moveSpeed <= 5.0f)
                    {
                        playerController.moveSpeed = 5.0f;
                    }
                    Debug.Log("Speed Down");
                    break;

                    // 20%
                case 2:
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
}
