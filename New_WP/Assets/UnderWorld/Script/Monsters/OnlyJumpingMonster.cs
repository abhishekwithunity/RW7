using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyJumpingMonster : MonoBehaviour
{
    public AudioClip soundDead;
    public GameObject deadFx;
    public int scoreRewarded = 200;
    public float speed = 0.02f;
    public float dieDelay = 1f;
    public float shootDelay;
    //[Range(0.001f, 0.01f)]
    [Range(0.05f, 2.0f)]
    public float jumpheight;//=0.001f;
    [Tooltip("Hit that layer object and turn direction")]
    public LayerMask LayerTurn;
    public AudioClip bounceoffrockfx;
    public GameObject hitfx;
    public Transform feetpostion;
    public GameObject feetposition;
    //public GameObject sawblade;
    //[Tooltip("The force of bullet when player throw it")]
    //public float throwForce;


    /// <summary>
    /// this is the addition of code to shoot objects 
    /// </summary>
    //[Tooltip("throw point to shoot small spikes")]
    //public Transform throwpoint;

    //public GameObject shootingspikes;

    private bool isDead = false;
    private float direction = -1f;
    private float speedWalk;
    //public AudioClip crabwalkaudiofx;
    float angle;
    // Use this for initialization
    void Start()
    {
        speedWalk = speed * -1;
        //SoundManager.PlaySfx(crabwalkaudiofx);
    }

    void FixedUpdate()
    {


        
        if (!isDead)
        {

            //transform.Translate (0,speedWalk,0);
            transform.Translate(speedWalk, 0, 0);

            // to make the platform go from top to botttom  transform.Translate (0,speedWalk,0);
            // To make the Platform go From Left to Right and vice versae transform.Translate (speedWalk,0,0);
           

            {
                StartCoroutine(waitanddropspike());



            }

            if (Physics2D.Raycast(transform.position, new Vector2(direction, 0), 0.45f, LayerTurn))
            {
                speedWalk *= -1;
                direction *= -1;
                transform.localScale = new Vector2(transform.localScale.x * -1, 1);
                StartCoroutine(waitanddropspike());
            }

        }
        ///
        //<summary>
        ///In this code the y axis of the object will change on every hit to the boundary
        /// if (Physics2D.Raycast (transform.position, new Vector2 (0,direction), 0.45f, LayerTurn))


        //    {
        //        speedWalk *= -1;
        //        direction *= -1;
        //        transform.localScale = new Vector2(1, transform.localScale.y * -1);
        //    }
        //}
        ///// 
        ///</summary>








        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2, LayerTurn);
        if (hit)
        {
            angle = Mathf.Atan2(hit.normal.y, hit.normal.x) * Mathf.Rad2Deg;
            //          angle= Vector2.Angle (hit.normal, Vector2.up);
            //          Debug.DrawRay (transform.position, hit.normal * 2);
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);


        }
    }

    public void Dead()
    {


        SoundManager.PlaySfx(soundDead);
        transform.localScale = new Vector3(1, 0.2f, 1);
        GameManager.Score += scoreRewarded;
        StartCoroutine(WaitAndDie());
    }

    IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(dieDelay);

        Instantiate(deadFx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    IEnumerator waitanddropspike()
    {
        yield return new WaitForSeconds(1.0f);

        // transform.Translate(speedWalk, jumpheight, 0);
        SoundManager.PlaySfx(bounceoffrockfx);
        transform.Translate(speedWalk+0.02f, jumpheight, 0);
       // Instantiate(hitfx, feetpostion.position, Quaternion.identity);




    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDead)
        {
            if (other.CompareTag("Player"))
            {
                isDead = true;
                Dead();
                //Push player up
                other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!isDead)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isDead = true;
                GameManager.instance.GameOver();
            }
        }
    }
}
