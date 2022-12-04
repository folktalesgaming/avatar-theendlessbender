using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed_f = 3.0f;
    private int health = 60;
    private Rigidbody2D enemy;
    private GameObject target;
    private LogicManager logicManager;

    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    void Update()
    {
        // transform.LookAt(target.position);
        // transform.Rotate(new Vector3(0,-90,0),Space.Self);

        if(Vector3.Distance(transform.position, target.transform.position) > 5.0f) {
        //     transform.Translate(new Vector3(speed_f * Time.deltaTime, 0, 0));
            // if(transform.position.y < target.transform.position.y) {
            //     transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 1f);    
            // }else {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed_f * Time.deltaTime);    
            // }
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;

        if(health <= 0) {
            logicManager.AddScore();
            Destroy(gameObject);
        }
    }
}
