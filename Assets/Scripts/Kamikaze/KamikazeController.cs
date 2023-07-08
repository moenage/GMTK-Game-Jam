using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeController : MonoBehaviour {

    public int hitPoints;
    public float kamikazeSpeed;
    public float rotationSpeed;

    public Rigidbody2D rb;

    public bool friendly;

    public Transform playerTarget; 

    public float fieldOfImpact;
    public float forceOfImpact;
    public LayerMask layerToHit;

    private void Start() {
        friendly = true;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.velocity = Vector2.zero;
    }


    private void FixedUpdate() {
        Vector2 direction = transform.position - playerTarget.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        rb.AddForce(direction * kamikazeSpeed, ForceMode2D.Impulse);

    }

    void explode() {
        Collider2D[] objectsExploded = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layerToHit);
        foreach(Collider2D obj in objectsExploded) {
            Vector2 directionExplode = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(directionExplode * forceOfImpact);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            hitPoints--;

            if (hitPoints <= 0) {
                explode();
                Destroy(gameObject);
            }
        }
        else if(collision.gameObject.tag == "Player") {
            explode();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall")) {
            // Get the wall's normal vector
            Vector2 wallNormal = collision.contacts[0].normal;

            // Calculate the parallel force direction
            Vector2 direction = transform.position - playerTarget.position;
            direction.Normalize();
            Vector2 parallelDirection = Vector2.Reflect(direction, wallNormal).normalized;

            // Apply continuous force along the wall's surface
            rb.AddForce(parallelDirection * kamikazeSpeed, ForceMode2D.Force);
        }
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }
}
