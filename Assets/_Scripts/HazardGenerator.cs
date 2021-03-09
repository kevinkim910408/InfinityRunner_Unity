using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardGenerator : MonoBehaviour
{
    public ObjectPooler objectPooler;

    public void SpawnHazard(Vector3 startPoint)
    {
        GameObject hazard = objectPooler.GetPooledObject();
        hazard.transform.position = startPoint;
        hazard.SetActive(true);
    }
}
