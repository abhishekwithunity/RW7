using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {
	public float time;
  //  public GameObject finishplayer;
    // Use this for initialization
	void Start () {

        //Instantiate(finishplayer, transform.position, Quaternion.identity);
		Destroy (gameObject, time);
       
	}
}
