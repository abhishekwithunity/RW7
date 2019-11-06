using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShark2 : MonoBehaviour
{
    //dealult is 500f
    public float jumpForce=500;
    //defualt is 60f
    //public float rotate= 60f;
                        //defualt is 0.35f
    public float delayAttack;
    public AudioClip soundAttack;
    public AudioClip soundDead;
    public GameObject deadFx;
    public GameObject AttackFx;
    public GameObject KillFx;
    //default is 200
    public int scoreRewarded= 200;
    private float movingspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Dead()
    {
        SoundManager.PlaySfx(soundDead);
        GameManager.Score += scoreRewarded;
        Instantiate(deadFx, transform.position, Quaternion.identity);
        Instantiate(KillFx, transform.position, Quaternion.identity);
        Instantiate(AttackFx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }




    void OnTriggerEnter2D(Collider2D other)
    {
       // if (isAttack)
        {
            if (other.CompareTag("Player"))
            {
                Dead();
                //Push player up
                other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                other.GetComponent<Rigidbody2D>().AddForce(new Vector2(-150f, 300f));
                Destroy(gameObject);
            }
        }
    }



    void OnCollisionEnter2D(Collision2D other)
    {
       // if (isAttack)
        {
            if (other.gameObject.CompareTag("Player"))
            {

                GameManager.instance.GameOver();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
