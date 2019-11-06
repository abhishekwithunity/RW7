using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplodeAttack : MonoBehaviour
{
    //dealult is 500f
    public float jumpForce = 0;
    //defualt is 60f
    public float rotate=0f;//= 60f;
                        //defualt is 0.35f
    public float delayAttack = 0.0f;
    public AudioClip soundAttack;
    public AudioClip soundDead;
    public GameObject deadFx;
    //default is 200
    public int scoreRewarded = 200;
    // private  float movingspeed;

    private bool isAttack = false;

    public void Attack()
    {
      //  transform.Rotate(Vector3.forward, rotate);
        StartCoroutine(WaitAndAttack(delayAttack));
    }

    IEnumerator WaitAndAttack(float time)
    {
        yield return new WaitForSeconds(time);
        SoundManager.PlaySfx(soundAttack);
        isAttack = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-jumpForce, 0));
        Destroy(gameObject);
    
    }

    public void Dead()
    {
        SoundManager.PlaySfx(soundDead);
        GameManager.Score += scoreRewarded;
        Instantiate(deadFx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (isAttack)
        {
            if (other.CompareTag("Player"))
            {
                //Dead();
                Instantiate(deadFx, transform.position, Quaternion.identity);
                Destroy(gameObject);
                //Push player up
                other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 3f));
                Debug.Log("Died from Ontriiger Method");
                GameManager.instance.GameOver();
                     
            }
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (isAttack)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.instance.GameOver();
                Dead();
                Debug.Log("Died from Oncollision Method");
                //Push player up
               // other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
               // other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));


            }
        }
    }
}