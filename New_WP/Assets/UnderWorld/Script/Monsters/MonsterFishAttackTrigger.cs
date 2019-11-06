using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFishAttackTrigger : MonoBehaviour
{
    //public MonsterFish monster;
    //replace sword by monster 
    public SwordFallingFromSkyCeiling Sword;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Sword.Attack();

            Destroy(gameObject);
            DestroytheMonster(1);
        }
    }

    IEnumerator DestroytheMonster(float time)
    {

        yield return new WaitForSeconds(time);
        Destroy(Sword);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
