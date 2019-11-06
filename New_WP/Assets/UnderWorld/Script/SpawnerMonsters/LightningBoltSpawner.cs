using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBoltSpawner : MonoBehaviour
{

    //public GameObject enemies;
    public GameObject[] typesofenemies;
    public GameObject[] enemyspawnpoint;
    public float spawnTime;//   = 5f;
    public float spawnDelay;// = 3f; 
    public int randomenemyspawnpoint;
    public int oldrandomenemyspawnpoint;
    public int randomenemies;


    //public GameObject MissilereleaseFx;
    public AudioClip lightingboltaudiofx;

    private void Start()
    {

    }

    private void Update()
    {
        // enemies.transform.localPosition = new Vector3(enemies.transform.position.x,enemies.transform.position.y,0.0f);
        randomenemyspawnpoint = Random.Range(0, enemyspawnpoint.Length);
        //for (i)
        randomenemies = Random.Range(0, typesofenemies.Length);
        InvokeRepeating("addenemy", spawnTime, spawnDelay);


    }


    public void addenemy()
    {
        //for (int i = 0; i < enemyspawnpoint.Length; i++)
        if (oldrandomenemyspawnpoint != randomenemyspawnpoint)
        {
           // SoundManager.PlaySfx(lightingboltaudiofx);
            //  Instantiate(MissilereleaseFx ,enemyspawnpoint[randomenemyspawnpoint].transform.position, Quaternion.identity);
            //Instantiate(enemies, enemyspawnpoint[randomenemyspawnpoint].transform.position, Quaternion.identity);
            Instantiate(typesofenemies[randomenemies], enemyspawnpoint[randomenemyspawnpoint].transform.position, Quaternion.identity);
            oldrandomenemyspawnpoint = randomenemyspawnpoint;
            CancelInvoke();
        }
    }

}
