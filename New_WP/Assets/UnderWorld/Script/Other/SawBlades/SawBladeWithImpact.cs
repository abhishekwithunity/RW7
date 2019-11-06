using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladeWithImpact : MonoBehaviour
{
     public AudioClip sawaudiofx;
     public GameObject hitfx;
     public Transform feetpostion;
     public float nextActionTime = 2.0f;
     public float period = 0.2f;
     void Start()
    {
      }

    void FixedUpdate()
    {


        
         
        {

             if (Time.time > nextActionTime)
            {
                
                nextActionTime += period;
                Instantiate(hitfx, feetpostion.position, Quaternion.identity);
                SoundManager.PlaySfx(sawaudiofx);
             }
            
            

        }
         


         
    }

   

    void OnBecameInvisible()
    {
     //   Destroy(gameObject);
    }

}
