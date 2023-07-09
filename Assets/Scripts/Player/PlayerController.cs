using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    float horizontalInput;
    float verticalInput;

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
}
