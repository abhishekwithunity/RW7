using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	[Header("Set up player value")]
	[Tooltip("speed of player")]
	public float speed = 0.07f;
	[Tooltip("Jump force of player")]
	public float jumpForce = 391f;
	[Tooltip("Gravity of player when is jumping in the air")]
	public float gravityJump = 1.2f;
	[Tooltip("Gravity of player when sliding")]
	public float gravitySlide = 5f;
	[Tooltip("The force of bullet when player throw it")]
	public float throwForce = 300f;
	[Header("JetPack")]
	public GameObject JetPack;
	[Tooltip("Force of jetpack when user hold the Jump button")]
	public float jetPackForce = 50f;
	[Tooltip("The fire fx of Jet Pack")]
	public ParticleSystem JetPackFire;
	[Tooltip("The position of bullet")]
	public Transform throwPoint;
	[Tooltip("Smoke position when player jump, slide")]
	public Transform smokePoint;
	[Tooltip("Place Bullet prefab here")]
    public GameObject Bullet;
    [Tooltip("Place Bullet prefab Effect here")]
    public GameObject BulletFx;
    [Tooltip("Place Smoke fx prefab here")]
	public GameObject smokeFx;
	[Tooltip("Place Jump fx prefab here")]
	public GameObject jumpFx;
	[Tooltip("Place the magnet from player here, this object will be set on and off during game")]
	public GameObject Magnet;
	[Tooltip("Time allow the magnet work")]
	public float magnetTimer = 10f;

    //[Tooltip("Place the super vehicle-1  for player here, this object will be set on and off during game")]
    //public GameObject sv1;
    //[Tooltip("Time allow the super-vehicle-1")]
    //public float sv1Timer = 10f;




    public bool bulletshot;

    ///<summary>
    /// The code and variables to make a dash move
    ///</summary>
    public float dashspeed;
    private float dashtime;
    public float startdashtime;
    private int dash_direction;
    public GameObject dasheffect;
    public GameObject speedincreeffect;

    /// <summary>
    /// Effect for GodSpeed
    /// </summary>
    [Tooltip("Place GodSpeed Hue fx prefab here")]
   // public GameObject godSpeedFx;


	public AudioClip soundJump;
	public AudioClip soundThrow;
	public AudioClip soundCollectBullet;
	public AudioClip soundEatFruit;

	[Tooltip("The Box Collider of upper body, this will be disabled when player sliding")]
	public BoxCollider2D boxColl1;
	public BoxCollider2D boxColl2;
	[Tooltip("Check ground point, this must be under player feet ")]
	public Transform checkGround;
	[Tooltip("The layers that are considered is the ground")]
	public LayerMask LayerGround;



	[Header("Animator Controller")]
	[Tooltip("Place the paremeters of Animator in here, useful to custom player")]
	public string walkTrigger = "Walk";
	public string isGroundBool = "isGround";
	public string slideBool = "Slide";
	public string thrownTrigger = "Thrown";
	public string dieTrigger = "Die";

	//private 
	public  Animator anim;
    public Rigidbody2D rig;
	private bool play = false;
	private bool die = false;
	private bool isGrounded = true;
	[HideInInspector]
	public bool isUsingJetPack = false;
	private bool isJumpHold = false;
	private float gravityNormal;
	private bool isCannonFiring = false;
	private bool isBoost = false;
	private float timeStuck = 0.1f;
    [Header("Bullet-1 Pattern Activator Flag")]
     public bool bullet1activated;
    [Header("Bullet-2 Pattern Activator Flag")]
    public bool bullet2activated;
    [Header("Bullet-3 Pattern Activator Flag")]
    public bool bullet3activated;
    [Header("Bullet-4 Pattern Activator Flag")]
    public bool bullet4activated;




	void Awake(){
		Magnet.SetActive (false);		//Turn of the magnet when begin game
       // sv1.SetActive(false);           //Turn Off the supervehicle-1 when game begins
    }

	// Use this for initialization
	void Start () {
        ///<summary
        /// all the bullet variations control flags are made false at 
        /// the start of the code
        /// </summary>

        bullet1activated = false;
        bullet2activated = false;
        bullet3activated = false;
        bullet4activated = false;


        startdashtime = 0.2f;
        dashspeed = 10;
        bulletshot = false;
        dashtime = startdashtime;
		//Set up variables
		rig = GetComponent<Rigidbody2D> ();
        //godSpeedFx.SetActive(false);

		gravityNormal = rig.gravityScale;		//save normal gravity scale
		anim = GetComponent<Animator> ();
		JetPack.SetActive (false);		//disable Jet pack object
        ///summary
        /// Im trying to make the PC swim as in ocean 
        /// soo making the velocity zero
        /// 
       // rig.velocity = Vector2.zero;


        if(GlobalValue.isUsingJetpack){
			isUsingJetPack = true;
            rig.velocity = Vector2.zero;
			JetPack.SetActive (true);
		
        
        
        }
	}
	
	// Update is called once per frame
	void Update () {
	
        //This is the Controller for PC
		if (!die) {		//stop doing anything when player dead - 
			if (Input.GetKeyDown (KeyCode.UpArrow)) {		//Only jump when player on the ground
				Jump();
			}
			if (Input.GetKeyUp (KeyCode.UpArrow)) {
				JumpOff ();
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				Attack ();
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				Slide (true);
			} 
			if (Input.GetKeyUp (KeyCode.DownArrow)) {
				Slide (false);
			}

			anim.SetFloat ("Height", rig.velocity.y);

		     
        }
	}

	void FixedUpdate(){
		if (!die) {		//stop doing anything when player dead
			if (play && !isCannonFiring) {		//only moving when play varible is true and not fire by the Big Cannon
				transform.Translate (new Vector3 (speed, 0, 0));		//moving the player with speed 
			}
			if (isUsingJetPack && isJumpHold) {		//if player got JetPack mode, the Jump button will be used to raise the player up
				rig.AddForce (new Vector2 (0, jetPackForce));
			}
            //isGrounded = false;

            anim.SetBool(isGroundBool, true);       //set animator
            isGrounded = true;
            /*
			//check if the player grounded
			if (Physics2D.OverlapCircle (checkGround.transform.position, 0.2f, LayerGround)) {
				anim.SetBool (isGroundBool, true);		//set animator
				isGrounded = true;
				isCannonFiring = false;	//if player fired out of the Cannon and hit the ground, allow moving
			} else {
				anim.SetBool (isGroundBool, false);		//set animator
				isGrounded = false;
			}

			*/


            if (rig.velocity.y == 0 && !isGrounded && !isUsingJetPack) {
				timeStuck -= Time.fixedDeltaTime;
				if (timeStuck <= 0)
					GameManager.instance.GameOver ();
			} else
				timeStuck = 0.1f;

				
		}
	}

	//Called by The Big Cannon
	public void CannonFire(){
		isCannonFiring = true;
		anim.SetTrigger (walkTrigger);
	}

	//Called by GameManager script
	public void Play(){
		if (anim != null)
			anim.SetTrigger (walkTrigger);
		play = true;
	}

	//Called by Controller UI and PC
	public void Jump(){
		if (!die) {		//stop doing anything when player dead
			isJumpHold = true;		//flag this bool to tell that user are holding the Jump buttons
			if (isUsingJetPack) {	//if using jet pack
				JetPackFire.emissionRate = 100f;	//inscrease fx effect
				JetPack.GetComponent<AudioSource> ().volume = 0.85f;		//inscrease jet pack sound volume
				rig.gravityScale = gravityNormal;

			}
			else if (isGrounded) {
				SoundManager.PlaySfx (soundJump);
				rig.gravityScale = gravityJump;
				rig.velocity = Vector2.zero;
				rig.AddForce (new Vector2 (0, jumpForce));
				Instantiate (jumpFx, smokePoint.position, Quaternion.identity);
			}
		}
	}

	//Called by Controller UI and PC
	public void JumpOff(){
		isJumpHold = false;
		if (isUsingJetPack) {
			JetPackFire.emissionRate = 25f;		
			JetPack.GetComponent<AudioSource> ().volume = 0.3f;
		} else
			rig.gravityScale = gravityNormal;
	}

	//
	//Slide
	//
	public void Slide(bool slide){
		if (!die) {
			anim.SetBool (slideBool, slide);
			if (slide) {
				boxColl1.enabled = false;		//turn the body collider off when sliding to avoid hit other collider
				boxColl2.enabled = false;
				StartCoroutine (CreateSmoke (0.1f));	//create smoke when sliding
				rig.gravityScale = gravitySlide;		//apply new gravity when sliding
			} else {
				boxColl1.enabled = true;		//turn the body collider on again
				boxColl2.enabled = true;
				StopAllCoroutines ();
				if(!isJumpHold)
					rig.gravityScale = gravityNormal;
			}
		}
	}

	IEnumerator CreateSmoke(float time){
		yield return new WaitForSeconds (time);
		if (isGrounded)	//only create smoke when player on the ground
			Instantiate (smokeFx, smokePoint.transform.position, Quaternion.identity);
		StartCoroutine (CreateSmoke (0.1f));	//create smoke when sliding
	}
	//
	//Called by Controller UI and PC
	public void Attack(){
        //private Vector3 rifle;
		if (!die && !isCannonFiring) {
            Vector3 dir15 = Quaternion.AngleAxis(15f, Vector3.forward) * Vector3.right;
            Vector3 dir0 = Quaternion.AngleAxis(0f, Vector3.forward) * Vector3.right;
            Vector3 dir55 = Quaternion.AngleAxis(120f, Vector3.forward) * Vector3.right;
       
			if (GameManager.Bullets > 0) {		//only allow throw the bullet when the amount of bullet greater then zero
                
                GameManager.Bullets--;
                Instantiate(BulletFx, throwPoint.position, Quaternion.identity);
				SoundManager.PlaySfx (soundThrow);
				anim.SetTrigger (thrownTrigger);		//set trigger to throw
                //GameObject obj = Instantiate (Bullet, throwPoint.position, Quaternion.AngleAxis (0, Vector3.forward)) as GameObject;
                throwPoint.rotation = Quaternion.Euler(0, 0, 45*throwPoint.localPosition.x);
                {
                    //StartCoroutine(shootabullet(0.01f, 45f));
                    //StartCoroutine(shootabullet(0.01f, 90f));
                    //StartCoroutine(shootabullet(0.01f, 135f));
                    //StartCoroutine(shootabullet(0.01f, 180f));
                }
                if (bullet1activated)
                {
                    StartCoroutine(shootabullet(0.01f, 0f));
                    StartCoroutine(shootabullet(0.01f, -190.0f));
                    bullet1activated = false;
                }
                else if (bullet2activated)
                {
                    StartCoroutine(shootabullet(0.01f, 15f));
                    StartCoroutine(shootabullet(0.01f, -15f));
                    bullet2activated = false;
                }

                else if (bullet3activated)
                {
                    StartCoroutine(shootabullet(0.01f, -15f));
                    StartCoroutine(shootabullet(0.01f, -35f));
                    StartCoroutine(shootabullet(0.01f, -60f));
                    bullet3activated = false;
                }
                else if (bullet4activated)
                {
                    StartCoroutine(shootabullet(0.01f, 0f));
                    StartCoroutine(shootabullet(0.01f, -190.0f));
                    bullet4activated = false;
                }
                else
                    StartCoroutine(shootabullet(0.01f, 0f));
                //GameObject obj = Instantiate (Bullet, throwPoint.position,throwPoint.rotation) as GameObject;
                //obj.GetComponent<Rigidbody2D>().AddForce(dir15 * throwForce);//AddRelativeForce (new Vector2 (throwForce, 0));
               
                //GameObject obj1 = Instantiate(Bullet, throwPoint.position, throwPoint.rotation) as GameObject;
                //obj1.GetComponent<Rigidbody2D>().AddForce(dir55 * throwForce);//AddRelativeForce (new Vector2 (throwForce, 0));





                //    obj.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (throwForce, 0));
        
            }
		}
	}

    

	//Called by GameManager script
	public void Dead(){
		if (!die) {
            Debug.Log("Died from"+transform.gameObject.name);
			die = true;
			anim.SetTrigger (dieTrigger);
			JetPack.SetActive (false);		//hide Jetpack when dead
			StopAllCoroutines ();
			//			rig.isKinematic = true;
			rig.velocity = Vector2.zero;
			rig.gravityScale = 0.0f;

			var boxCo = GetComponents<BoxCollider2D> ();
			foreach (var box in boxCo) {
				box.enabled = false;
			}
			var CirCo = GetComponents<CircleCollider2D> ();
			foreach (var cir in CirCo) {
				cir.enabled = false;
			}

		}
	}

	//Detect the gameobjects via their tag
	void OnTriggerEnter2D(Collider2D other){
		
        if (other.gameObject.CompareTag("SpeedBoost"))
         {   Debug.Log("Dash Enabled");
            other.GetComponent<CircleCollider2D> ().enabled = false;
            //SoundManager.PlaySfx (soundEatFruit, 0.5f);
            //GameManager.Hearts++;
            rig.velocity = Vector2.right * dashspeed;
            Instantiate(dasheffect, transform.position,Quaternion.identity);
            Destroy(other.gameObject, 0.01f); 

            //if (dash_direction == 0)//if dash is in progress
            //{ 
            //    dash_direction = 1; 
            //}
            //else
            //{ if (dashtime <= 0)
            //    { dash_direction = 0;
            //        dashtime = startdashtime;
            //    }
            //      else
            //    {
            //        dashtime -= Time.deltaTime;
                  
            //         if (dash_direction==1)
            //        {
            //            rig.velocity = Vector2.left * dashspeed;
                            
            //        }
            //    }
            //}
        
        }

        else if(other.gameObject.CompareTag("BulletVar1"))
        {
            Debug.Log("BulletVar1Enabled");
            other.GetComponent<CircleCollider2D>().enabled = false;
            bullet1activated = true;
            Destroy(other.gameObject, 0.01f);

        }
        else if (other.gameObject.CompareTag("BulletVar2"))
        {
            Debug.Log("BulletVar2Enabled");
            other.GetComponent<CircleCollider2D>().enabled = false;
            bullet2activated = true;
            Destroy(other.gameObject, 0.01f);

        }
        else if (other.gameObject.CompareTag("BulletVar3"))
        {
            Debug.Log("BulletVar3Enabled");
            other.GetComponent<CircleCollider2D>().enabled = false;
            bullet3activated = true;
            Destroy(other.gameObject, 0.01f);

        }
        else if (other.gameObject.CompareTag("BulletVar4"))
        {
            Debug.Log("BulletVar4Enabled");
            other.GetComponent<CircleCollider2D>().enabled = false;
            bullet4activated = true;
            Destroy(other.gameObject, 0.01f);

        }

        else if (other.gameObject.CompareTag ("Fruit")) {
			other.GetComponent<CircleCollider2D> ().enabled = false;
			SoundManager.PlaySfx (soundEatFruit, 0.5f);
			GameManager.Hearts++;
			other.gameObject.GetComponent<Animator> ().SetTrigger ("Collected");
		}
		else if (other.gameObject.CompareTag ("Bullet")) {
			SoundManager.PlaySfx (soundCollectBullet);
			GameManager.Bullets += 10;
			Destroy (other.gameObject);
		}
        else if (other.gameObject.CompareTag("SuperVehicle1"))
        {
            Debug.Log("SuperVehicle Collected");
            SoundManager.PlaySfx(soundCollectBullet);
       //     sv1.SetActive(true);
       //     StartCoroutine(WaitAndDisableSuperVehicle(sv1Timer));
           // Destroy(other.gameObject);
        }


		else if (other.gameObject.CompareTag ("Magnet")) {
			SoundManager.PlaySfx (soundCollectBullet);
			Magnet.SetActive (true);
			StartCoroutine (WaitAndDisableMagnet (magnetTimer));
			Destroy (other.gameObject);
		}
		else if (other.gameObject.CompareTag ("Star")) {
			other.GetComponent<CircleCollider2D> ().enabled = false;
			SoundManager.PlaySfx (soundCollectBullet, 0.7f);
			GameManager.Stars++;
			GameManager.Score += 10;
			other.gameObject.GetComponent<Animator> ().SetTrigger ("Collected");
		}

		else if (other.gameObject.CompareTag ("Bridge")) {
            Debug.Log ("bridge");
			other.gameObject.SendMessage ("Work", SendMessageOptions.DontRequireReceiver);
		}
		else if (other.gameObject.CompareTag ("JetPack")) {
			isUsingJetPack = !isUsingJetPack;
			rig.velocity = Vector2.zero;
			JetPack.SetActive (isUsingJetPack);
			Destroy (other.gameObject);
		}
		else if (other.gameObject.CompareTag ("SpeedIncrease")) {
            if (!isBoost)
            {
                //                godSpeedFx.SetActive(true);
                Instantiate(speedincreeffect, transform.position, Quaternion.identity);
                isBoost = true;
                speed *= 2.00f;
                Destroy(other.gameObject, 0.01f);
                isBoost = false;
            }

			//Destroy (other.gameObject);
		}
        else if (other.gameObject.CompareTag ("SlowSpeed")) {
            //if (!isBoost)
            {
                //                godSpeedFx.SetActive(true);
                Instantiate(speedincreeffect, transform.position, Quaternion.identity);
                //isBoost = true;
                speed /= 1.20f;
                Destroy(other.gameObject, 0.01f);
                //isBoost = false;
            }

            //Destroy (other.gameObject);
        }
    
    
    
    }

    IEnumerator shootabullet(float time,float angle)
    {
        Vector3 angleofbullet = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
        GameObject obj = Instantiate (Bullet, throwPoint.position,throwPoint.rotation) as GameObject;
        obj.GetComponent<Rigidbody2D>().AddForce(angleofbullet * throwForce);//AddRelativeForce (new Vector2 (throwForce, 0));
               
       
        yield return new WaitForSeconds(time);
    }
	//Disable the Magnet after the time delay
	IEnumerator WaitAndDisableMagnet(float time){
		yield return new WaitForSeconds (time);
		Magnet.SetActive (false);
	}


    //Disable the Super Vehicle after the time delay
    IEnumerator WaitAndDisableSuperVehicle(float time){
        yield return new WaitForSeconds (time);
     //   sv1.SetActive (false);
       // Destroy(sv1);
    }





    //Disable the God Speed Effect
    IEnumerator WaitAndDisableMagnet_GodSpeedEffect(float time)
    {
        yield return new WaitForSeconds(time);
       // godSpeedFx.SetActive(false);
      //  Destroy(godSpeedFx);
    }
	//Detect the Enemy collider and send Game over to GameManager script
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Enemy")) {
			GameManager.instance.GameOver ();
		}
        
    
    
    
    
    }
}
