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
    public Text coinText = null;
    public Text bestCoinText = null;

    public float scoreCount;
    public float highScoreCount;
    public float milesCount;
    public float bestMilesCount;
    public float coinCount;
    public float bestCoinCount;

    public float scoreIncreaseCount;
    public float mileIncreaseCount;

    public bool isScoreIncrease;

    // Start is called before the first frame update
    void Start()
    {
        isScoreIncrease = true;

        // load
        if (PlayerPrefs.GetFloat("HighScore") != null && PlayerPrefs.GetFloat("BestMiles") != null && PlayerPrefs.GetFloat("Coins") != null)
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
            bestMilesCount = PlayerPrefs.GetFloat("BestMiles");
            bestCoinCount = PlayerPrefs.GetFloat("Coins");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isScoreIncrease)
        {
            milesCount += mileIncreaseCount * Time.deltaTime;
            scoreCount += (milesCount + scoreIncreaseCount) * Time.deltaTime;
        }


        // save
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
        if (coinCount > bestCoinCount)
        {
            bestCoinCount = coinCount;
            PlayerPrefs.SetFloat("Coins", bestCoinCount);
        }



        // text edit
        scoreText.text = "SCORE: " + scoreCount.ToString("N0");
        highScoreText.text = "HIGH SCORE: " + highScoreCount.ToString("N0");

        milesText.text = "MILES: " + milesCount.ToString("N0");
        bestMilesText.text = "BEST MILES: " + bestMilesCount.ToString("N0");

        coinText.text = "COINS: " + coinCount.ToString("N0");
        bestCoinText.text = "BEST COINS: " + bestCoinCount.ToString("N0");
    }
}
