using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // components
    public PlayerController controller = null;

    private Vector3 targetPosition = Vector3.zero;
    private float distanceToMove = 0.0f;

    [SerializeField] private float offsetZ = -15.0f; 

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<PlayerController>();

        targetPosition = controller.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove = controller.transform.position.x - targetPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, offsetZ);

        targetPosition = controller.transform.position;   
    }
}
