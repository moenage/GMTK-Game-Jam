using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuboidController : MonoBehaviour
{

    public int hitPoints;
    public float cuboidSpeed;
    public float cuboidTimedShots;

    public Transform playerTarget;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private bool canShoot;

    private void Start() {
        canShoot = true;
    }

    private void FixedUpdate() {

        if (canShoot) {
            cuboidFire();
        }

        else {
            Vector2 direction = playerTarget.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.position = Vector2.MoveTowards(this.transform.position, playerTarget.position, cuboidSpeed * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
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

            if (hitPoints <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
