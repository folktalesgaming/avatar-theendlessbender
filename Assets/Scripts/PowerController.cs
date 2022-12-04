using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
{
    private float speed_f = 20.0f;
    private Rigidbody2D power;
    private EnemyController enemyController;

    void Start()
    {
        power = GetComponent<Rigidbody2D>();
        power.velocity = transform.right * speed_f;
    }

    void Update()
    {
        if(transform.position.x > 15 || transform.position.x < -15) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")) {
            enemyController = other.gameObject.GetComponent<EnemyController>();
            enemyController.TakeDamage(20);
            Destroy(gameObject);
        }
    }
}
