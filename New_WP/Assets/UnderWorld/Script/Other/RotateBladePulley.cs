using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBladePulley : MonoBehaviour
{
    [Range(0.5f, 500.0f)]
    public float speed;//= 0.5f;
   
    private void Awake()
    {
        //    source = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {

       // StartCoroutine(PlaySoundEffect());
        transform.Rotate(Vector3.forward, speed);
    }
    IEnumerator PlaySoundEffect()
    {
        //source.PlayOneShot(sawbladefx, volume);
      //  Instantiate(SawBreakingFx, BreakingPos.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
