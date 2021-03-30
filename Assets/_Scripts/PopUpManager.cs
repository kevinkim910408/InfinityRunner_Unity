using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    public GameObject popUpPanel = null;
    public Text popUpText;

    // Start is called before the first frame update
    void Start()
    {
        popUpPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Visible()
    {
        popUpPanel.SetActive(true);

        Invoke("Invisible", 1.0f);
    }

    public void Invisible()
    {
        popUpPanel.SetActive(false);
    }
}
