using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingProj : MonoBehaviour
{
    public GameObject shoot_projectile;
    public float timebetweenshots;
    public float starttimebetweenshots;
    public Transform shootingnozzle;
    public GameObject BulletImpactfx;
    public AudioClip AudioImpact;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timebetweenshots <= 0)
        {
           // SoundManager.PlaySfx(AudioImpact);
            Instantiate(BulletImpactfx, shootingnozzle.position, Quaternion.identity);
            Instantiate(shoot_projectile, shootingnozzle.position, Quaternion.identity);
            shoot_projectile.GetComponent<Rigidbody2D>().AddForce(shootingnozzle.forward * 10);
           //     .GetComponent<Rigidbody>().AddForce(transform.forward * 10);                
            timebetweenshots = starttimebetweenshots;
        }
        else
        {
            timebetweenshots -= Time.deltaTime;
        }
        
    }
}
