using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fish_jumpattack : MonoBehaviour
{
    public GameObject hitFx;
    public MonsterFish monster;
    public AudioClip soundhitfx;


    private void Start()
    {
        monster = GetComponentInParent<MonsterFish>();
      //  soundhitfx = ("Assets/UnderWorld/Audio/Effect/Cannon");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(hitFx, monster.transform.position, Quaternion.identity);
            SoundManager.PlaySfx(soundhitfx);  
    
            monster.Attack();

            Destroy(gameObject);
            DestroytheMonster(1);
        }
        Instantiate(hitFx, monster.transform.position, Quaternion.identity);
        SoundManager.PlaySfx(soundhitfx);  
    }

    IEnumerator DestroytheMonster(float time)
    {

        yield return new WaitForSeconds(time);
        Destroy(monster);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
