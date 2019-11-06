using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_HitDown : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject HitEffect;
    // public GameObject impactEffect;

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.TransformDirection(Vector3.down * speed);
       // hitPlayer.velocity = transform.TransformDirection(Vector3.forward * 100);
        rb.SetRotation(-180.0f);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(HitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
