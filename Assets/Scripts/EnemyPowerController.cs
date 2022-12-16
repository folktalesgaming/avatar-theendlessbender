using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPowerController : MonoBehaviour
{
    private float speed_f = 20.0f;
    private Rigidbody2D power;
    private PlayerController playerController;

    void Start()
    {
        power = GetComponent<Rigidbody2D>();
        power.velocity = transform.right * speed_f;
    }

    void Update()
    {
        if(transform.position.x > 35 || transform.position.x < -35) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) {
            playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
