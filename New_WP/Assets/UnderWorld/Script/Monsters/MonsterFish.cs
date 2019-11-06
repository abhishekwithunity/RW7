using UnityEngine;
using System.Collections;

public class MonsterFish : MonoBehaviour {
    //dealult is 500f
    public float jumpForce = 500;
    //defualt is 60f
    public float rotate;//= 60f;
    //defualt is 0.35f
	public float delayAttack=0.35f;
	public AudioClip soundAttack;
	public AudioClip soundDead;
	public GameObject deadFx;
   // public GameObject ImpactFx;

    //default is 200
    public int scoreRewarded= 200;
   // private  float movingspeed;
    private void Start()
    {
     //   movingspeed = 0.099f;
    }
    private void FixedUpdate()
    {
       // transform.Translate(-movingspeed, 0, 0);
    }
    private bool isAttack = false;

	public void Attack(){
        transform.Rotate (Vector3.forward, rotate);
		StartCoroutine (WaitAndAttack (delayAttack));
       
    }

	IEnumerator WaitAndAttack(float time){
		
		SoundManager.PlaySfx (soundAttack);
		isAttack = true;
		GetComponent<Rigidbody2D> ().isKinematic = false;
		GetComponent<Rigidbody2D> ().AddRelativeForce(new Vector2(-jumpForce,0));
        yield return new WaitForSeconds(time);

    }

	public void Dead(){
		SoundManager.PlaySfx(soundDead);
		GameManager.Score += scoreRewarded;
		Instantiate (deadFx, transform.position, Quaternion.identity);
		//Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){

        ///<summary>
        /// With these two lines of code the
        /// objects will hit the ground and 
        /// disaappear with Impactfx
        /// </summary>
      //  Instantiate(ImpactFx, transform.position, Quaternion.identity);//new line added 
        Instantiate(deadFx, transform.position, Quaternion.identity);
       Destroy(gameObject,0.75f);//new line added 
               
		if (isAttack) {
			if (other.CompareTag ("Player")) {
				Dead ();
				//Push player up
				other.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
				other.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 300f));
			}
		}
	}


	void OnCollisionEnter2D(Collision2D other){
        Instantiate(deadFx, transform.position, Quaternion.identity);

        if (isAttack) 
        {
			if (other.gameObject.CompareTag ("Player")) {
				GameManager.instance.GameOver ();
			}
		}
	}
}