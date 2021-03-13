using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    Animator playerAnimator;
    Rigidbody playerRigid;

    private PlatformDestruction[] platformList;

    ScoreManager scoreManager;
    TimeManager timeManager;


    public string restartSceneName = "";
    public string menuSceneName = "";
    public GameObject losePanel = null;



    private void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
        timeManager = FindObjectOfType<TimeManager>();

        playerAnimator = thePlayer.GetComponent<Animator>();
        playerRigid = thePlayer.GetComponent<Rigidbody>();

        losePanel.gameObject.SetActive(false);

    }

    public void RestartGame()
    {
        thePlayer.isDead = false;
        losePanel.gameObject.SetActive(false);

        //set false. to stop
        scoreManager.isScoreIncrease = false;
        timeManager.isTimeDecrease = false;


        thePlayer.gameObject.SetActive(false);
        //yield return new WaitForSeconds(0.5f);

        platformList = FindObjectsOfType<PlatformDestruction>();
        for (int i = 0; i < platformList.Length; ++i)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = playerStartPoint;
        thePlayer.gameObject.SetActive(true);


        // reset score and timer
        Time.timeScale = 1.0f;

        scoreManager.isScoreIncrease = true;
        scoreManager.scoreCount = 0;
        scoreManager.milesCount = 0;
        scoreManager.coinCount = 0;

        timeManager.isTimeDecrease = true;
        timeManager.currentTime = 60;
    }
   

    public void GoMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void LoseCondition()
    {
        thePlayer.isDead = true;
        playerAnimator.SetBool("isDie",true);
        losePanel.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
