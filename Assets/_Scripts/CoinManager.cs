using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    ScoreManager scoreManager;
    public int coinScore;

    // sounds
    AudioSource audioSource;
    [SerializeField] AudioClip coinClip = null;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        audioSource = GameObject.FindGameObjectWithTag("CoinSFX").GetComponent<AudioSource>();
    }

    public void PlaySound(string action)
    {
        switch (action)
        {
            case "COIN":
                audioSource.clip = coinClip;
                break;
        }
        audioSource.Play();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlaySound("COIN");
            scoreManager.coinCount += 1;
            scoreManager.scoreCount += 100;

            gameObject.SetActive(false);
        }
    }
}
