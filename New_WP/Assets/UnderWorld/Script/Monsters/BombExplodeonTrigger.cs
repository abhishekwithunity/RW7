using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplodeonTrigger : MonoBehaviour
{
    public GameObject hitFx;
   // public BombExplodeAttack bomb;
    public AudioClip soundhitfx;


    private void Start()
    {
       // hitFx.SetActive(false);
       // bomb = GetComponentInParent<BombExplodeAttack>();
        //  soundhitfx = ("Assets/UnderWorld/Audio/Effect/Cannon");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(hitFx, transform.position, Quaternion.identity);
            SoundManager.PlaySfx(soundhitfx);
            Destroy(gameObject);
            Debug.Log("Hit from Ontrigger Method");

            //Push player up
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10f));
           
         
       
             }
        }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(hitFx, transform.position, Quaternion.identity);
            SoundManager.PlaySfx(soundhitfx);
            Destroy(gameObject);
            Debug.Log("Hit from Collision Method");
            collision.otherRigidbody.velocity = Vector2.zero;
            collision.otherRigidbody.AddForce(new Vector2(0, 10f));
           
            //    .GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            // (new Vector2(0, 10f));//collision.GetComponent<Rigidbody2D>().AddForce
            GameManager.instance.GameOver();


        }
    }
    public void BlowupBomb()
    {
        
           
    }


}