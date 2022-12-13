using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player;
    private Joystick joystick;
    private float speed_f = 5.0f;
    private float jump_force_f = 3.0f;
    private bool isOnGround = true;
    public float rangeBoundX;
    private bool is_facing_right;
    private float jumpInterval = 0.5f;
    private float jumpedTime;
    private float shootInterval = 1f;
    private float shootedTime;
    private int health = 150;
    public GameObject powerPrefab;
    public Transform firePoint;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        is_facing_right = true;
        joystick = FindObjectOfType<Joystick>();
        shootedTime = 1f;
    }

    void Update()
    {
        float keyHorizontal = Input.GetAxis("Horizontal");
        float joyHorizontal = joystick.Horizontal;

        bool checkOutOfbound = ((transform.position.x < -rangeBoundX && (keyHorizontal < 0 || joyHorizontal < 0)) 
                                || (transform.position.x > rangeBoundX && (keyHorizontal > 0 || joyHorizontal > 0)));

        jumpedTime += Time.deltaTime;
        shootedTime += Time.deltaTime;

        // bound the player movement to the range bound
        if(checkOutOfbound) {
            transform.Translate(Vector3.right * 0);
        }else {
        // else make the player move
            if(is_facing_right) {
                transform.Translate(Vector3.right * speed_f * Time.deltaTime * joyHorizontal);
                transform.Translate(Vector3.right * speed_f * Time.deltaTime * keyHorizontal);
            }else {
                transform.Translate(Vector3.left * speed_f * Time.deltaTime * joyHorizontal);
                transform.Translate(Vector3.left * speed_f * Time.deltaTime * keyHorizontal);
            }
        }

        // rotate the player
        if((keyHorizontal < 0 || joyHorizontal < 0) && is_facing_right) {
            is_facing_right = false;
            FlipCharacter();
        }else if((keyHorizontal > 0 || joyHorizontal > 0) && !is_facing_right) {
            is_facing_right = true;
            FlipCharacter();
        }

        // make the player jump when on ground and pressed either Space or W key
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || joystick.Vertical > 0) && isOnGround && jumpedTime > jumpInterval) {
            Jump();
        }

        // shoot the power when left mouse clicked
        // if(Input.GetMouseButtonDown(0)) {
        //     Shoot();
        // }
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        // When collided with Ground or Platform make the isOnGround to true
        if((collisionInfo.gameObject.CompareTag("Ground") || collisionInfo.gameObject.CompareTag("Platform"))) {
            isOnGround = true;
        }
    }

    public void Shoot() {
        if(shootedTime > shootInterval) {
            shootedTime = 0f;
            Instantiate(powerPrefab, firePoint.position, transform.rotation);
        }
    }

    public void Jump() {
        if(isOnGround) {
            transform.Translate(Vector3.up * jump_force_f);
            isOnGround = false;
            jumpedTime = 0f;
        }
    }

    // TODO: Check for reliability and make a hurt pause similar to enemy
    public void TakeDamage(int damage) {
        health -= damage;

        if(health <= 0) {
            Destroy(gameObject);
        }
    }

    private void FlipCharacter() {
        transform.Rotate(0f, 180f, 0f);
    }
}
