using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed_f = 5.0f;
    private float jumpForce = 1.0f;
    private int health = 60;
    private Rigidbody2D enemy;
    private GameObject target;
    private LogicManager logicManager;
    public GameObject powerfab;
    public Transform firePoint;
    private float shootInterval = 2f;
    private float shootedTime;
    private bool isHurt = false;

    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    void Update()
    {
        shootedTime += Time.deltaTime;

        // TODO: List below
        /** 
            - Make the chase more smoother
            - Make enemy chase player to top
            - Make the enemy distance either random or calculate each enemy position or make waves of enemy
        **/
        if(!logicManager.isGameOver()) {
            if(Vector2.Distance(transform.position, target.transform.position) > 5.0f) {
                if (target.transform.position.y > transform.position.y)
                {
                    enemy.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }else {
                    transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed_f * Time.deltaTime);    
                }
            } else {
                if(!isHurt)
                    AttackPlayer();
            }
        }
    }

    // TODO: Check for performance and reliability for this coroutine
    public IEnumerator TakeDamage(int damage) {
        health -= damage;
        isHurt = true;

        if(health <= 0) {
            logicManager.AddScore();
            Destroy(gameObject);
        }

        yield return new WaitForSeconds(1.5f);

        isHurt = false;
    }

    void AttackPlayer() {
        if(shootedTime > shootInterval) {
            shootedTime = 0f;
            Instantiate(powerfab, firePoint.position, transform.rotation);
        }
    }
}
