using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFiringMissle : MonoBehaviour
{
    
public CircleCollider2D coll1;
public Transform CanonBody;
public Transform FirePoint;
public GameObject MissileHead;
public GameObject SmokeFx;
public AudioClip soundFire;
    public float force;//Default = 750f;
                       //private PlayerController player;
    public MissileShoot missile;
private Animator anim;
private bool isRotate = false;

// Use this for initialization
void Start()
{
    //player = FindObjectOfType<PlayerController>();

    anim = GetComponent<Animator>();
}

// Update is called once per frame
void Update()
{
        if (isRotate)
    {
        SoundManager.PlaySfx(soundFire);
            anim.SetBool("Rotate", false);
            MissileHead.SetActive(false);
            missile.transform.position = FirePoint.position;
            missile.transform.rotation = FirePoint.rotation;
            missile.gameObject.SetActive(true);
       // player.CannonFire();
            missile.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            missile.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(force, 0));
            missile.transform.rotation = Quaternion.identity;
        Instantiate(SmokeFx, FirePoint.position, Quaternion.identity);
        isRotate = false;
    }
}

void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.CompareTag("Monster"))
    {
        anim.SetBool("Rotate", true);
        isRotate = true;
            //player.GetComponent<Animator>().SetTrigger("Reset");
            StartCoroutine(DisablePlayer(0.1f));

            //coll1.enabled = false;
    }
}

IEnumerator DisablePlayer(float time)
{
    yield return new WaitForSeconds(time);
        missile.gameObject.SetActive(true);
        // penguinHead.SetActive(true);
   // player.gameObject.SetActive(false);
}
}
