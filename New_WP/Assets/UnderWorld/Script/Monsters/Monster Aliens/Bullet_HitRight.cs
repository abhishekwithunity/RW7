using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_HitRight : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject HitEffect;
    // public GameObject impactEffect;

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.right * speed;
        rb.SetRotation(-90.0f);

    }

    void OnCollisionEnter2D(Collision2D other)
    { 
        Instantiate(HitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
