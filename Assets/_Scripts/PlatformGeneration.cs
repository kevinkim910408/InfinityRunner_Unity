using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] Transform generationPoint = null; 

    [Header("Platform_Distance")]
    [SerializeField] float distanceBetweenPlatforms = 0.0f;
    [SerializeField] float distanceMin = 0.0f;
    [SerializeField] float distanceMax = 0.0f;

    // object pool

    [Header("RandomPlatform")]
    public ObjectPooler[] objectPooler;
    private int platformSelector; 
    public float maxHeight;
    public float minHeight;
    private float heightChange;
    public float maxHeightChange;
    public Transform maxHeightPoint;

    CoinGenerator coinGenerator;


    // Start is called before the first frame update
    void Start()
    {
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        coinGenerator = FindObjectOfType<CoinGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        // so camera's x position passed the transform position, make a platform
        if (transform.position.x < generationPoint.position.x)
        {
            // random distance
            distanceBetweenPlatforms = Random.Range(distanceMin, distanceMax);
            platformSelector = Random.Range(0, platformPrefab.Length);

            transform.position = new Vector3(transform.position.x + distanceBetweenPlatforms, heightChange, transform.position.z);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange < maxHeight && heightChange > transform.position.y )
            {
                heightChange = maxHeight;
            }
            else if(heightChange > minHeight && heightChange < transform.position.y)
            {
                heightChange = minHeight + (maxHeight * 0.5f);
            }
            else if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }



            //Instantiate(platformPrefab, transform.position, transform.rotation);



            GameObject newPlatform = objectPooler[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            coinGenerator.SpawnCoin(new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z));

        }
    }
}
