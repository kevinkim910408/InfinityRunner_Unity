using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGGenerator : MonoBehaviour
{
    public ObjectPooler objectPooler;

    public void SpawnBG(Vector3 startPoint)
    {
        GameObject BG = objectPooler.GetPooledObject();
        BG.transform.position = startPoint;
        BG.SetActive(true);
    }
}
