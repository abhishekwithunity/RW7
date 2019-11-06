using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Aline_2 : MonoBehaviour
{
    public Transform firePoint,firepoint2;
    public GameObject bulletPrefab;
    public float delayforshoot = 10.0f;
    public float timebetweenshots = 2.0f;
    public float starttimebetweenshots = 1.0f;
    public GameObject ShootingEffect;
    public AudioClip shootingaudio;

    // Update is called once per frame
    void Update()
    {

        if (timebetweenshots <= 0)
        {
            SoundManager.PlaySfx(shootingaudio);
            Instantiate(ShootingEffect, firePoint.position, Quaternion.identity);
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Instantiate(ShootingEffect, firePoint.position, Quaternion.identity);
            Instantiate(bulletPrefab, firepoint2.position, Quaternion.identity);
            timebetweenshots = starttimebetweenshots;
            //Destroy(bulletPrefab, 0.50f);
        
        }
        else
        {
            timebetweenshots -= Time.deltaTime;
        }

    }




}
