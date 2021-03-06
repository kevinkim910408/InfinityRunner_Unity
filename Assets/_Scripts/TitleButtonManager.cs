using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour
{

    public string startSceneName = "";

    public GameObject creditPanel = null;

    private void Start()
    {
        creditPanel.gameObject.SetActive(false);
    }

    public void GoStart()
    {
        SceneManager.LoadScene(startSceneName);
    }

    public void GoExit()
    {
        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();
    }
    
    public void GoCredit()
    {
        creditPanel.gameObject.SetActive(true);
    }

    public void GoBack()
    {
        creditPanel.gameObject.SetActive(false);
    }
}
