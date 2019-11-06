using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Alien_PrefabType : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float delayforshoot=10.0f;
    public float timebetweenshots=2.0f;
    public float starttimebetweenshots=1.0f;
    public GameObject ShootingEffect;
    public AudioClip shootingaudio;
    //public GameObject muzzleffect;
    // Update is called once per frame
    void Update()
    {

        if (timebetweenshots <= 0)
        {
            //SoundManager.PlaySfx(shootingaudio);
            Instantiate(ShootingEffect, firePoint.position, Quaternion.identity);
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            timebetweenshots = starttimebetweenshots;
        }
        else
        {
            timebetweenshots -= Time.deltaTime;
        }

    }
     
}
