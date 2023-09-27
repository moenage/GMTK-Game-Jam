using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float timedShots;
    private bool canShoot;

    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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
        audioManager.playSFX(audioManager.laserSound);

        StartCoroutine(shotCooldwon());
    }

    IEnumerator shotCooldwon() {
        yield return new WaitForSeconds(timedShots);
        canShoot = true;
    }
}
