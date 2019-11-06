using UnityEngine;
using System.Collections;

public class DetectMonsterFalling : MonoBehaviour {
	public Rigidbody2D monsterIV;
	public AudioClip soundShowUp;


    private void Start()
    {
        monsterIV.isKinematic = false;
            
    }
    // Use this for initialization
    void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			SoundManager.PlaySfx (soundShowUp);
            monsterIV.isKinematic = false;

            Destroy (gameObject);
		}
	}
}
