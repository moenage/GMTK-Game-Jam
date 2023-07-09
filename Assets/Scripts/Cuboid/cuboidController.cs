using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuboidController : MonoBehaviour
{
    public int hitPoints;
    public float cuboidSpeed;
    public float cuboidTimedShots;
    public float shootingRange;

    public Transform playerTarget;
    public Transform firePoint;
    public GameObject bulletPrefab;

    [SerializeField] private ParticleSystem deathPlosion;

    private bool canShoot;

    private void Start() {
        canShoot = true;
        playerTarget = GameObject.FindWithTag("Player").transform;
    }

    private void Update() {
        Vector2 direction = playerTarget.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        float distanceFromPlayer = Vector2.Distance(playerTarget.position, transform.position);

        if (canShoot) {
            cuboidFire();
        }

        if (distanceFromPlayer > shootingRange) { 
            transform.position = Vector2.MoveTowards(this.transform.position, playerTarget.position, cuboidSpeed * Time.fixedDeltaTime);
        }

            
    }

    public void cuboidFire() {
        canShoot = false;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        StartCoroutine(cuboidShotCooldwon());
    }

    IEnumerator cuboidShotCooldwon() {
        yield return new WaitForSeconds(cuboidTimedShots);
        canShoot = true;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            hitPoints--;
        }
        else if(collision.gameObject.tag == "Bouncy") {
            hitPoints--;
        }
        if (hitPoints <= 0) {
            ParticleSystem explodeMe = Instantiate(deathPlosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
