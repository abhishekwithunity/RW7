using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyplatform : MonoBehaviour
{

    public AudioClip soundDead;
    public GameObject deadFx;
    //public int scoreRewarded = 200;

    private void Start()
    {
        deadFx.SetActive(false);
    
    
    }


    public void changetherigidbody2d()
    {
        Debug.Log("Rigidbody changed");
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("rock has hit the Player");
            deadFx.SetActive(true);
          
            SoundManager.PlaySfx(soundDead);
           // other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
           // other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
            Instantiate(deadFx, transform.position, Quaternion.identity);
           // Destroy(other.gameObject);
            GameManager.instance.GameOver();

        }
        }


    void OnCollisionEnter2D(Collision2D other)
    { if (other.gameObject.CompareTag("Monster"))
        {
          
            deadFx.SetActive(true);
            //Debug.Log("Hit GreenPlatform");
            SoundManager.PlaySfx(soundDead);
            Instantiate(deadFx, transform.position, Quaternion.identity);
            Destroy(other.gameObject);

        }
       
    

    }
    
}
