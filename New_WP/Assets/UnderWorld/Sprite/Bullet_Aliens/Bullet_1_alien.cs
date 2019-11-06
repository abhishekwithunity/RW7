using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_1_alien : MonoBehaviour
{
	 
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
   // public GameObject impactEffect;

    // Use this for initialization
    void Start () {
        rb.velocity = transform.right * speed;
        rb.SetRotation(-90.0f);
           
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //SoundManager.PlaySfx(soundHit);
            // Instantiate(hitFx, other.transform.position, Quaternion.identity);
            // Destroy(other.gameObject);
        }
        else
        {
            //SoundManager.PlaySfx(soundMiss);
            //Instantiate(missFx, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }  
}
