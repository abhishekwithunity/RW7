using UnityEngine;
using System.Collections;

public class MonsterFishDetect : MonoBehaviour
{
    public SharkAttacking  monster;

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
