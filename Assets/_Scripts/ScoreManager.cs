using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText = null;
    public Text highScoreText = null;
    public Text milesText = null;
    public Text bestMilesText = null;

    public float scoreCount;
    public float highScoreCount;
    public float milesCount;
    public float bestMilesCount;

    public float scoreIncreaseCount;
    public float mileIncreaseCount;


    public bool isScoreIncrease;

    // Start is called before the first frame update
    void Start()
    {
        isScoreIncrease = true;

        if(PlayerPrefs.GetFloat("HighScore") != null && PlayerPrefs.GetFloat("BestMiles") != null)
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
            bestMilesCount = PlayerPrefs.GetFloat("BestMiles");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isScoreIncrease)
        {
            milesCount += mileIncreaseCount * Time.deltaTime;
            scoreCount += scoreIncreaseCount * Time.deltaTime;

        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }
        if (milesCount > bestMilesCount)
        {
            bestMilesCount = milesCount;
            PlayerPrefs.SetFloat("BestMiles", bestMilesCount);
        }

        scoreText.text = "SCORE: " + scoreCount.ToString("N0");
        highScoreText.text = "HIGHSCORE: " + highScoreCount.ToString("N0");

        milesText.text = "MILES: " + milesCount.ToString("N0");
        bestMilesText.text = "BESTMILES: " + bestMilesCount.ToString("N0");
    }
}
