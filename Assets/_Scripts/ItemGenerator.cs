using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemGenerator : MonoBehaviour
{
    public ObjectPooler objectPooler;

    public void SpawnItem(Vector3 startPoint)
    {
        GameObject Item = objectPooler.GetPooledObject();
        Item.transform.position = startPoint;
        Item.SetActive(true);
    }
}