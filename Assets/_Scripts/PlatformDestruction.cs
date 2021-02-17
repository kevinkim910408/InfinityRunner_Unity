using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestruction : MonoBehaviour
{
    [SerializeField] GameObject destructionPoint = null;

    // Start is called before the first frame update
    void Start()
    {
        destructionPoint = GameObject.Find("DestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < destructionPoint.transform.position.x)
        {
            Destroy(gameObject); 
        }
    }
}
