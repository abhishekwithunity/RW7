using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrigger : MonoBehaviour
{
    public destroyplatform desplatform;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            desplatform.changetherigidbody2d();
            Destroy(gameObject);
            DestroytheMonster(1);
        }
    }

    IEnumerator DestroytheMonster(float time)
    {

        yield return new WaitForSeconds(time);
        Destroy(desplatform);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}