using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;

    Vector3 moveVector;

    private void Start() {
        moveVector = Vector3.up * bulletSpeed * Time.fixedDeltaTime;
    }

    private void FixedUpdate() {
        transform.Translate(moveVector);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
}
