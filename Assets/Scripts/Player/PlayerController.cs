using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private GameObject powerPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Button fireButton;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameoverScreenController gameOverScreenController;

    private float speed_f = 5.0f;
    private float jump_force_f = 8.0f;
    private bool isOnGround = true;
    public float rangeBoundX;
    private bool is_facing_right;
    private bool is_moving = false;
    private float shootInterval = 1f; // made shoot interval more for harder gameplay for now
    private float shootedTime;
    private float health = 160;
    private float maxHealth;
    
    private LogicManager logicManager;

    void Start()
    {
        is_facing_right = true;
        shootedTime = 1f;
        maxHealth = health;
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    void Update()
    {
        // TODO: create healthbar vanish fix
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        bool checkOutOfbound = ((transform.position.x < -rangeBoundX && !is_facing_right) 
                                || (transform.position.x > rangeBoundX && is_facing_right));

        shootedTime += Time.deltaTime;

        // bound the player movement to the range bound
        if(checkOutOfbound) {
            transform.Translate(Vector3.right * 0);
            is_moving = false;
        }else {
            if(is_moving) {
                if(is_facing_right) {
                    if(transform.rotation.y >= 0) {
                        transform.Translate(Vector3.right * speed_f * Time.deltaTime);
                    }else {
                        transform.Translate(Vector3.left * speed_f * Time.deltaTime);
                    }
                }else {
                    if(transform.rotation.y >= 0) {
                        transform.Translate(Vector3.left * speed_f * Time.deltaTime);
                    }else {
                        transform.Translate(Vector3.right * speed_f * Time.deltaTime);
                    }
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        // When collided with Ground or Platform make the isOnGround to true
        if((collisionInfo.gameObject.CompareTag("Ground") || collisionInfo.gameObject.CompareTag("Platform"))) {
            isOnGround = true;
        }
    }

    private void ReEnableShootButton() {
        fireButton.interactable = true;
    }

    public void Shoot() {
        if(shootedTime > shootInterval) {
            fireButton.interactable = false;
            Invoke("ReEnableShootButton", shootInterval);
            shootedTime = 0f;
            Instantiate(powerPrefab, firePoint.position, transform.rotation);
        }
    }

    public void MoveForward() {
        is_moving = true;
        if(!is_facing_right){
            is_facing_right = true;
            FlipCharacter();
        }
    }


    public void MoveBackward() {
        is_moving = true;
        if(is_facing_right){
            is_facing_right = false;
            FlipCharacter();
        }
    }

    public void StopMoving() {
        is_moving = false;
    }

    public void Jump() {
        if(isOnGround) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jump_force_f, ForceMode2D.Impulse);
            // transform.Translate(Vector3.up * jump_force_f);
            isOnGround = false;
        }
    }

    // TODO: Check for reliability and make a hurt pause similar to enemy
    public void TakeDamage(int damage) {
        health -= damage;

        if(health <= 0) {
            gameOverScreenController.GameoverSetup(logicManager.getScore());
            gameObject.SetActive(false);
            TimedModeOverlay.Instance.SetOverlayText("Game Over");
            logicManager.SetGameOver();
        }
    }

    private void FlipCharacter() {
        transform.Rotate(0f, 180f, 0f);
    }
}
