using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocuhController : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void ShootPower()
    {
        playerController.Shoot();
    }
}
