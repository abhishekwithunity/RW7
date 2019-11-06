using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundExplosionEffect : MonoBehaviour
{
    public GameObject effect_explosion;
    public Animator pc_anim;

    // Start is called before the first frame update
    void Start()
    {
        pc_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("OnCompleteAttackAnimation");


       
    }

    IEnumerator OnCompleteAttackAnimation()
    {
        while (pc_anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
          
        Instantiate(effect_explosion, transform.position, Quaternion.identity);
        //Destroy(effect_explosion);
        DestroyObject(effect_explosion);
        // TODO: Do something when animation did complete
        yield return null;
    }


}
