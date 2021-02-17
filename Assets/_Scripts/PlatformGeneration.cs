using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] GameObject platformPrefab = null;
    [SerializeField] Transform generationPoint = null; 

    [Header("Platform_Distance")]
    [SerializeField] float distanceBetweenPlatforms = 0.0f;
    [SerializeField] float distanceMin = 0.0f;
    [SerializeField] float distanceMax = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // so camera's x position passed the transform position, make a platform
        if(transform.position.x < generationPoint.position.x)
        {
            // random distance
            distanceBetweenPlatforms = Random.Range(distanceMin, distanceMax);
            
            transform.position = new Vector3(transform.position.x + distanceBetweenPlatforms, transform.position.y, transform.position.z);

            Instantiate(platformPrefab, transform.position, transform.rotation);
        }
    }
}
