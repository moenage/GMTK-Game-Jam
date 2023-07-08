using UnityEngine;

public class BouncyController : MonoBehaviour {

    public float BouncySpeed;
    public int hitPoints;

    private cuboidController cuboidController;

    private Vector2 direction;

    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        direction = GetRandomDirection();
    }

    private void FixedUpdate() {
        // Move the object in the chosen direction
        rb.velocity = direction * BouncySpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Reflect the direction upon colliding with a wall
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Cuboid")) {
            Vector2 normal = collision.contacts[0].normal;
            direction = Vector2.Reflect(direction, normal).normalized;
        }
        else if (collision.gameObject.tag == "Bullet") {
            hitPoints--;

            if (hitPoints <= 0) {
                Destroy(gameObject);
            }
        }
        //else if (collision.gameObject.tag == "Player") {
           
        //}
    }

    private Vector2 GetRandomDirection() {
        // Generate a random direction vector
        float randomAngle = Random.Range(0f, 360f);
        return Quaternion.Euler(0f, 0f, randomAngle) * Vector2.right;
    }
}
