using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {
    public float EnemyBulletSpeed;

    Vector3 moveVector;

    private void Start() {
        moveVector = Vector3.up * EnemyBulletSpeed * Time.fixedDeltaTime;
    }

    private void FixedUpdate() {
        transform.Translate(moveVector);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
}
