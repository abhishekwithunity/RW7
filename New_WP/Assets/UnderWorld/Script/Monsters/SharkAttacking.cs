using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkAttacking : MonoBehaviour
{
    //dealult is 500f     public float jumpForce;// = 500;     //defualt is 60f     public float rotate;//= 60f;     //defualt is 0.35f  public float delayAttack;   public AudioClip soundAttack;   public AudioClip soundDead;     public GameObject deadFx;
    public GameObject AttackFx;
    public GameObject KillFx;
     //default is 200     public int scoreRewarded;// = 200;     private  float movingspeed;     private void Start()     {         movingspeed = 0.099f;     }     private void FixedUpdate()     {         transform.Translate(-movingspeed, 0, 0);
       
     }     private bool isAttack = false;     public void Attack(){         transform.Rotate (Vector3.forward, rotate);         StartCoroutine (WaitAndAttack (delayAttack));          
    }   IEnumerator WaitAndAttack(float time){
              yield return new WaitForSeconds (time);         SoundManager.PlaySfx (soundAttack);
                isAttack = true;         GetComponent<Rigidbody2D> ().isKinematic = false;         GetComponent<Rigidbody2D> ().AddRelativeForce(new Vector2(-jumpForce,0));         Instantiate(deadFx, transform.position, Quaternion.identity);
       
        Destroy(gameObject);
    
    }   public void Dead(){         SoundManager.PlaySfx(soundDead);         GameManager.Score += scoreRewarded;         Instantiate (deadFx, transform.position, Quaternion.identity);
        Instantiate(KillFx, transform.position, Quaternion.identity);
        Instantiate(AttackFx, transform.position, Quaternion.identity);         Destroy (gameObject);   }   void OnTriggerEnter2D(Collider2D other){        if (isAttack) {             if (other.CompareTag ("Player")) {              Dead ();                //Push player up                 other.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;                 other.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-150f, 300f));                 Destroy(gameObject); 
            }       }   }       void OnCollisionEnter2D(Collision2D other){         if (isAttack) {             if (other.gameObject.CompareTag ("Player")) {
                               GameManager.instance.GameOver ();           }     }   } } 
