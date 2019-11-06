using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour {

	public float delayFalling = 0.1f;
	public AudioClip soundBridge;

	//send from PlayerController
	public void Work(){
        Debug.Log("Called1");
		SoundManager.PlaySfx (soundBridge);
		GetComponent<Animator> ().SetTrigger ("Shake");
		StartCoroutine (Falling (delayFalling));
	}

	IEnumerator Falling(float time){
		yield return new WaitForSeconds (time);
        Debug.Log("Called");
        GetComponent<Rigidbody2D> ().isKinematic = false;
         
		enabled = false;	 
	}
}
