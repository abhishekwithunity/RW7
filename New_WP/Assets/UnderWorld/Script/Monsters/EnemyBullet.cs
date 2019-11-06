using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
	public float speed = 0.05f;
	public AudioClip soundDead;
	public GameObject deadFx;
	public int scoreRewarded = 200;
//    public AudioClip hitotheraudiofx;
     
    /* 
         New Lines added 
        */
       
//    public GameObject impacteffect;

	private bool isStop = false;


    private void Start()
    {
       // transform.Rotate(0, 0, -180); 
        transform.Rotate(0, 0,  0); 
    }
    // Update is called once per frame
    void FixedUpdate () {
		if (!isStop)
			transform.Translate (-speed, 0, 0);
       
        //earlier working with "-speed"
	}

	void OnBecameInvisible() {
		Destroy (gameObject);	//destroy this object when invisible
	}

	public void Dead(){
		SoundManager.PlaySfx(soundDead);
		GameManager.Score += scoreRewarded;
		Instantiate (deadFx, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
  //      Instantiate(impacteffect, transform.position, Quaternion.identity);
  //      SoundManager.PlaySfx(hitotheraudiofx);
        Destroy(gameObject);
			if (other.CompareTag ("Player")) {
				Dead ();
				//Push player up
				other.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
				other.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 300f));
			}
       /* 
         New Lines added 
        */
  


        if (other.gameObject.CompareTag("LeftDestroyWall"))
        {
            Destroy(gameObject);
            Debug.Log("Touched the Wall");
        }
    }


	void OnCollisionEnter2D(Collision2D other){
    //    Instantiate(impacteffect, transform.position, Quaternion.identity);
    //    SoundManager.PlaySfx(hitotheraudiofx);
    //    Destroy(gameObject);
		if (other.gameObject.CompareTag ("Player")) {
			isStop = true;
			GameManager.instance.GameOver ();
		}

    if (other.gameObject.CompareTag("LeftDestroyWall"))
        {
            Destroy(gameObject);
            Debug.Log("Touched the Wall");
        }
	}

}
