using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timerText = null;
    public float timerDecreaseCount;
    public float currentTime;

    public bool isTimeDecrease;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        isTimeDecrease = true;
        currentTime = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimeDecrease)
        {
            currentTime -= timerDecreaseCount * Time.deltaTime;
        }

        if(currentTime <= 0)
        {
            currentTime = 0;
            timerText.text = "GAME OVER";
            gameManager.LoseCondition();
        }

        timerText.text = "TIME: " + currentTime.ToString("N0");
    }
}
