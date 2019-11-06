using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperVeh : MonoBehaviour
{
  //  public AudioClip soundMiss;
 //   public AudioClip soundHit;
    public GameObject hitFx;
 //   public GameObject missFx;
 //   public Vector2 newbullposn;
    // Use this for initialization
    void Start()
    {
      //  newbullposn = transform.position;


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            /*
for adding sound effects later
            */
            //SoundManager.PlaySfx(soundHit);
            //working code 
       //     Instantiate(hitFx, other.transform.position, Quaternion.identity);
       //     Destroy(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
            Debug.Log("touched anything");
        }   
    
        //Destroy(gameObject);
    }

    void OnTriggerEnter2d(Collider2D other)
    {
        Destroy(other.gameObject);
        Debug.Log("touched anything");
    }

}
