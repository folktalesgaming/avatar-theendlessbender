using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
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

    public void Jump() 
    {
        playerController.Jump();
    }
    
    public void MoveForward() 
    {
        playerController.MoveForward();
    }
    
    public void MoveBackward() 
    {
        playerController.MoveBackward();
    }

    public void StopMoving()
    {
        playerController.StopMoving();
    }
}
