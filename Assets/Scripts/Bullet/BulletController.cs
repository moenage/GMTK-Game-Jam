using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float bulletSpeed;

    Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        moveVector = Vector3.up * bulletSpeed * Time.deltaTime;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(moveVector);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
}
