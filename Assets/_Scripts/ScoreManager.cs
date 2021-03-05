using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText = null;
    public Text highScoreText = null;

    public float scoreCount;
    public float highScoreCount;

    public float scoreIncreaseCount;
    public bool isScoreIncrease;

    // Start is called before the first frame update
    void Start()
    {
        isScoreIncrease = true;

        if(PlayerPrefs.GetFloat("HighScore") != null)
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isScoreIncrease)
        {
            scoreCount += scoreIncreaseCount * Time.deltaTime;

        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }
        scoreText.text = "SCORE: " + scoreCount.ToString("N0");
        highScoreText.text = "HIGHSCORE: " + highScoreCount.ToString("N0");
    }
}
