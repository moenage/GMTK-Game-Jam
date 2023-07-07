using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float timedShots;
    private bool canShoot;

    private void Start() {
        canShoot = true;
    }

    private void Update() {
        if (Input.GetMouseButton(0) && canShoot) {
            Fire();
        }
    }

    public void Fire() {
        canShoot = false;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        StartCoroutine(shotCooldwon());
    }

    IEnumerator shotCooldwon() {
        yield return new WaitForSeconds(timedShots);
        canShoot = true;
    }
}
