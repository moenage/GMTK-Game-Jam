using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Vector2 PlayerInput;

    // Update is called once per frame
    void Update() {
        PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate() {
        Vector2 moveForce = PlayerInput * moveSpeed;
        rb.velocity = moveForce;
    }
}