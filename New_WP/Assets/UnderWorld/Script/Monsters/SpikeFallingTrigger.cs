using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFallingTrigger : MonoBehaviour
{
    public MonsterFish monster;
    //replace sword by monster 
    //public SwordFallingFromSkyCeiling Sword;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            monster.Attack();

            Destroy(gameObject);
            DestroytheMonster(1);
        }
    }

    IEnumerator DestroytheMonster(float time)
    {

        yield return new WaitForSeconds(time);
        Destroy(monster);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
