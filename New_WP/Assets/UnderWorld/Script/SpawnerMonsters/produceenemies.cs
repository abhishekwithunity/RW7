using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will spawn a monster at spawnpoint 
/// triggered by the triggerpoints
/// </summary>

public class produceenemies : MonoBehaviour
{
    
    public GameObject enemies;
    public GameObject[] enemyspawnpoint;
    public float spawnTime;//   = 5f;
    public float spawnDelay;// = 3f; 
    public int randomenemyspawnpoint;
    public int oldrandomenemyspawnpoint;
   // public GameObject MissilereleaseFx;
   // public AudioClip missilereleaseaudiofx;

    private void Start()
    {
        
    }

    private void Update()
    {
       // enemies.transform.localPosition = new Vector3(enemies.transform.position.x,enemies.transform.position.y,0.0f);
        randomenemyspawnpoint = Random.Range(0, enemyspawnpoint.Length);
        //for (i)
        InvokeRepeating("addenemy", spawnTime, spawnDelay);

 
    }

     
    public void addenemy()
    {
        //for (int i = 0; i < enemyspawnpoint.Length; i++)
        if (oldrandomenemyspawnpoint != randomenemyspawnpoint)
        {
          //  SoundManager.PlaySfx(missilereleaseaudiofx);
          //  Instantiate(MissilereleaseFx ,enemyspawnpoint[randomenemyspawnpoint].transform.position, Quaternion.identity);
            Instantiate(enemies, enemyspawnpoint[randomenemyspawnpoint].transform.position, Quaternion.identity);
            oldrandomenemyspawnpoint = randomenemyspawnpoint;
            CancelInvoke();
        }
    }

}
