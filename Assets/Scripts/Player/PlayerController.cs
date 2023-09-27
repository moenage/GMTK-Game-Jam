using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 5f;

    public Image healthBar;
    public float healthAmount;

    public static event Action onPlayerDeath;

    private Rigidbody2D rb;
    private Vector2 movement;
    float horizontalInput;
    float verticalInput;

    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() {
        // Calculate movement vector
        movement = new Vector2(horizontalInput, verticalInput) * moveSpeed;
        // Apply movement to the rigidbody
        rb.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Cuboid" || collision.gameObject.tag == "Kamikaze") {
            healthAmount = healthAmount - 10;
            healthBar.fillAmount = healthAmount / 100f;
            audioManager.playHit(audioManager.playerHit);
        }
        if(healthAmount <= 0) {
            onPlayerDeath?.Invoke();
        }
    }
}
