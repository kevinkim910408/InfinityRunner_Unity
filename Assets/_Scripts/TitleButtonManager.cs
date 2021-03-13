using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour
{
    
    public string startSceneName = "";

    public GameObject creditPanel = null;
    public GameObject InstructionPanel = null;

    //components
    Animator animator;

    //boolean
    bool isCreadit;
    bool isInstruction;

    private void Start()
    {
        animator = GetComponent<Animator>();

        Time.timeScale = 1;
        creditPanel.gameObject.SetActive(false);
        InstructionPanel.gameObject.SetActive(false);

        isCreadit = false;
        isInstruction = false;
    }

    public void GoStart()
    {
        animator.SetTrigger("FadeOut");


        StartCoroutine("TitleFadeOut");
    }

    IEnumerator TitleFadeOut()
    {
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(startSceneName);
    }

    public void GoExit()
    {
        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();
    }
    
    public void GoCredit()
    {
        isCreadit = true;
        creditPanel.gameObject.SetActive(true);
    }

    public void GoInstruction()
    {
        isInstruction = true;
        InstructionPanel.gameObject.SetActive(true);
    }

    public void GoBack()
    {
        if (isCreadit)
        {
            creditPanel.gameObject.SetActive(false);
            isCreadit = false;
        }
        else if (isInstruction)
        {
            InstructionPanel.gameObject.SetActive(false);
            isInstruction = false;
        }
    }
}
