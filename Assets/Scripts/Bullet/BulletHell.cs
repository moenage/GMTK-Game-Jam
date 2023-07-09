using UnityEngine;

public class BulletHell : MonoBehaviour {
    public GameObject bulletPrefab;
    public int bulletCount = 10;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    public float rotationSpeed = 30f;

    public bool bulletHellOn = false;
    public float bulletHellDuration = 5f;
    public float bulletHellExtension = 2f; // Duration extension upon collision

    private float timer = 0f;
    private float bulletHellTimer = 0f;
    private float remainingDuration = 0f;

    private void Update() {
        if (bulletHellOn) {
            bulletHellTimer += Time.deltaTime;

            if (bulletHellTimer >= remainingDuration) {
                bulletHellOn = false;
                bulletHellTimer = 0f;
            }

            timer += Time.deltaTime;
            if (timer >= fireRate) {
                FireBulletWave();
                timer = 0f;
            }
        }
    }

    private void FireBulletWave() {
        float angleStep = 360f / bulletCount;
        float currentAngle = 0f;

        for (int i = 0; i < bulletCount; i++) {
            // Calculate the position and rotation of each bullet in the wave
            Vector3 bulletPosition = transform.position;
            Quaternion bulletRotation = Quaternion.Euler(0f, 0f, currentAngle);

            // Instantiate a bullet from the prefab
            GameObject bullet = Instantiate(bulletPrefab, bulletPosition, bulletRotation);

            // Get the bullet's Rigidbody2D component
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            // Set the bullet's velocity
            bulletRb.velocity = bullet.transform.up * bulletSpeed;

            // Increase the angle for the next bullet
            currentAngle += angleStep;
        }
    }

    private void FixedUpdate() {
        if (bulletHellOn) {
            // Rotate the object based on the rotationSpeed
            transform.Rotate(Vector3.forward * rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bouncy") {
            bulletHellOn = true;
            remainingDuration += bulletHellExtension;
        }
    }
}
