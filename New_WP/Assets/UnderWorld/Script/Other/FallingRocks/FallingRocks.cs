using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRocks : MonoBehaviour
{

    public float delayFalling;// = 0.1f;
    public AudioClip Fallingrocksaudiofx;
    public float delayAttack = 0.35f;
    public AudioClip soundAttack;
    public AudioClip soundDead;
    public GameObject deadFx;
    //public GameObject breakingpiecesrockfx;
    //default is 200
    public int scoreRewarded = 200;
    // private  float movingspeed;
    private void Start()
    {
        //   movingspeed = 0.099f;
    }
    private void FixedUpdate()
    {
        // transform.Translate(-movingspeed, 0, 0);
    }
    //private bool isAttack = false;
  

    //send from PlayerController
    public void Work()
    {
        
        SoundManager.PlaySfx(Fallingrocksaudiofx);
        GetComponent<Animator>().SetTrigger("Shake");
        StartCoroutine(Falling(delayFalling));
       
    }

    IEnumerator Falling(float time)
    {
        yield return new WaitForSeconds(time);
      //  GetComponent<Rigidbody2D>().isKinematic = false;
      //  enabled = false;

    }

 
    public void Dead()
    {
        SoundManager.PlaySfx(soundDead);
        GameManager.Score += scoreRewarded;
        //Instantiate(deadFx, transform.position, Quaternion.identity);
        //Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(" OntriggerEnter2d Event Triggered");
      //  if (isAttack)
        {
            if (other.CompareTag("Player"))
            {
                // Instantiate(deadFx, transform.position, Quaternion.identity);
                // Destroy(gameObject);
                Debug.Log("Hit by OntriggerEnter2d");
                Dead();
                //Push player up
                other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
                //Destroy(gameObject);
            }


        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        
            Instantiate(deadFx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        
        //if (isAttack)
        {
            if (other.gameObject.CompareTag("Player"))
            {Debug.Log("Hit by OnCollisionEnter2d");
               // 
               // Destroy(gameObject);
                GameManager.instance.GameOver();
                Instantiate(deadFx, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }


}
 