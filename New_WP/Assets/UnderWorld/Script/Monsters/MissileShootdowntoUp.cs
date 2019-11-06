using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileShootdowntoUp : MonoBehaviour
{ 
    /// <summary>
    /// This missile will go from bottom to up
    /// </summary>


    public float speed = 0.05f;
    public AudioClip soundDead;
    public GameObject deadFx;
    public int scoreRewarded = 200;
    public AudioClip hitotheraudiofx;
    public Vector3 shootDirection;
    /// <summary>
    /// Select one of the options to shoot from different postion 
    /// </summary>
    ///<remarks>
    /// Select one of the options to shoot from different postion 
    /// </remarks>
    private bool shootfromceiling;
    private bool shootfromground;
    private bool shootfromleft;
    private bool shootfromright;

    /* 
         New Lines added 
        */

    public GameObject impacteffect;

    private bool isStop = false;
    private void Start()
    {
        shootfromceiling = true;
        shootfromleft = false;
        shootfromright = false;
        shootfromground = false;



        if (shootfromceiling)
        {
            transform.Rotate(0, 0, -180);
        }
        if (shootfromground)
        {
            transform.Rotate(0, 0, -180);
        }
        if (shootfromright)
        {
            transform.Rotate(0, 0, 90);
        }
        if (shootfromleft)
        {
            transform.Rotate(0, 0, -90);
        }




    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!isStop)
        {
            if (shootfromceiling)
            {
                // transform.Rotate(0, 0, -90);
                transform.Translate(0, -speed, 0);
            }
            if (shootfromground)
            {
                transform.Translate(0, -speed, 0);
            }
            if (shootfromright)
            {
                // transform.Rotate(0, 0, 180);
                transform.Translate(speed, 0, 0);
            }
            if (shootfromleft)
            {
                transform.Translate(speed, 0, 0);
            }




        }

        // new line addded
        //older transform.Translate(speed,0, 0);
        //transform.Translate(0,-speed, 0); up to down
        //transform.Translate(0,speed, 0); down to up


    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);    //destroy this object when invisible
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
        Instantiate(impacteffect, transform.position, Quaternion.identity);
        SoundManager.PlaySfx(hitotheraudiofx);
        Destroy(gameObject);
        if (other.CompareTag("Player"))
        {
            Dead();
            //Push player up
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
        }
        /* 
          New Lines added 
         */

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(impacteffect, transform.position, Quaternion.identity);
        SoundManager.PlaySfx(hitotheraudiofx);
        Destroy(gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            isStop = true;
            GameManager.instance.GameOver();
        }
    }
}
