using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler objectPooler;
    public float distanceBetweenCoins;

    public void SpawnCoin(Vector3 startPoint)
    {
        GameObject coin = objectPooler.GetPooledObject();
        coin.transform.position = startPoint;
        coin.SetActive(true);

        GameObject coin2 = objectPooler.GetPooledObject();
        coin2.transform.position = new Vector3(startPoint.x - distanceBetweenCoins, startPoint.y, startPoint.z);
        coin2.SetActive(true);

        GameObject coin3 = objectPooler.GetPooledObject();
        coin3.transform.position = new Vector3(startPoint.x + distanceBetweenCoins, startPoint.y, startPoint.z);
        coin3.SetActive(true);
    }
}
