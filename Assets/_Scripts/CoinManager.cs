using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    ScoreManager scoreManager;
    public int coinScore;

    // sounds

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scoreManager.coinCount += 1;
            scoreManager.scoreCount += 100;

            gameObject.SetActive(false);
        }
    }
}
