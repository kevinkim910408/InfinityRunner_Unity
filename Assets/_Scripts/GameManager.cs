using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestruction[] platformList;

    ScoreManager scoreManager;
    TimeManager timeManager;

    private void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
        timeManager = FindObjectOfType<TimeManager>();
    }

    public void RestartGame()
    {
        StartCoroutine("ResatartGameCo");
    }
    public IEnumerator ResatartGameCo()
    {
        //set false. to stop
        scoreManager.isScoreIncrease = false;
        timeManager.isTimeDecrease = false;


        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        platformList = FindObjectsOfType<PlatformDestruction>();
        for(int i = 0; i < platformList.Length; ++i)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = playerStartPoint;
        thePlayer.gameObject.SetActive(true);


        // reset score and timer
        scoreManager.isScoreIncrease = true;
        scoreManager.scoreCount = 0;

        timeManager.isTimeDecrease = true;
        timeManager.currentTime = 60;

    }
}
