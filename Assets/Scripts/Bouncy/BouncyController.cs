using UnityEngine;

public class BouncyController : MonoBehaviour {

    public float BouncySpeed;
    public int hitPoints;

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
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Cuboid") || collision.gameObject.CompareTag("Kamikaze")) {
            Vector2 normal = collision.contacts[0].normal;
            direction = Vector2.Reflect(direction, normal).normalized;
        }
        //else if (collision.gameObject.tag == "Bullet") {
        //    hitPoints--;
        //}
        else if (collision.gameObject.tag == "Player") {
            hitPoints = 0;
        }
        if (hitPoints <= 0) {
            Destroy(gameObject);
        }
    }

    private Vector2 GetRandomDirection() {
        // Generate a random direction vector
        float randomAngle = Random.Range(0f, 360f);
        return Quaternion.Euler(0f, 0f, randomAngle) * Vector2.right;
    }
}
