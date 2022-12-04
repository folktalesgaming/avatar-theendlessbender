using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 tempCameraPosition;

    [SerializeField]private float maxY, minY;

    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        tempCameraPosition = transform.position;
        tempCameraPosition.y = playerTransform.position.y;

        if (tempCameraPosition.y < minY)
            tempCameraPosition.y = minY;
        if (tempCameraPosition.y > maxY)
            tempCameraPosition.y = maxY;

        transform.position = tempCameraPosition;
    }
}
