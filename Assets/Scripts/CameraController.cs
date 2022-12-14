using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 tempCameraPosition;

    [SerializeField]private float maxX, minX;

    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        tempCameraPosition = transform.position;
        tempCameraPosition.x = playerTransform.position.x;

        if (tempCameraPosition.x < minX)
            tempCameraPosition.x = minX;
        if (tempCameraPosition.x > maxX)
            tempCameraPosition.x = maxX;

        transform.position = tempCameraPosition;
    }
}
