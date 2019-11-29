using UnityEngine;
using System.Collections;

public class MonsterFishDetect : MonoBehaviour
{
  //  public SharkAttacking  monster;
    public MonsterFish fish;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fish.Attack();

            Destroy(gameObject);
            DestroytheMonster(1);
        }
    }

    IEnumerator DestroytheMonster(float time)
    {

        yield return new WaitForSeconds(time);
        Destroy(fish);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
