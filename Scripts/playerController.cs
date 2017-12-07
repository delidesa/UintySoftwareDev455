using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

	public GameObject escapeMenu;//Reference to the escape menu
	private float timestamp=0.0f;//Used to control how fast the menu spawns/despawns
	bool menuActive = false;//Start the escape menu inactive
	//movement variables
	public float maxSpeed;

	//jump variables
	bool grounded = false;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public Transform ceilingCheck;
	Vector2 ceilingY = new Vector2(0.0f,1.0f);
	public float jumpHeight;

	//Animation/physics variables
	bool facingRight;
	Rigidbody2D playerRB;
	Animator myAnim;
	SpriteRenderer playerSR;

	//For card attack
	public Transform spawnTip;
	public GameObject projectileObject;
	float fireRate = 1.0f;
	float nextFire = 0f;

	//Vanish skill
	public Image VanishCD;
	bool isVanished = false;
	float vanishCooldown = 20.0f;
	float vanishDuration = 5.0f;
	float durationOfVanish;
	float vanishOffCooldown=0.0f;
	float timeOfVanish=0.0f;

	//Audio
	//public AudioSource audio;
	//public AudioClip cardAttackSound;

	// Use this for initialization
	void Start () 
	{
		playerRB = GetComponent<Rigidbody2D>();
		playerSR = GetComponent<SpriteRenderer>();
		myAnim = GetComponent<Animator>();
		facingRight = true;
		VanishCD.fillAmount = 0.0f;//off cooldown
	}
	
	// Update is called once per frame
	void Update()
	{
		if (grounded && Input.GetAxis("Jump") > 0) //Player can jump
		{
			grounded = false;
			myAnim.SetBool("isGrounded", grounded);
			playerRB.AddForce(new Vector2(0,jumpHeight));
			RaycastHit2D ceilingCheck = Physics2D.Raycast (new Vector2(transform.position.x, transform.position.y + 0.5f), Vector2.up, 3.0f);
			print(ceilingCheck.collider.tag);
			if(ceilingCheck.collider.tag == "Platform") //If the raycast hits the ceiling
			{
				playerRB.AddForce(new Vector2(0,-155));
				print("Hit Ceiling");
			}
		}
		//Vanish logic - reset player to default values
		if (isVanished && durationOfVanish < Time.time) 
		{
			isVanished = false;
			transform.gameObject.tag = "Player";//Set the player tag back to 'Player'
			playerSR.color = new Color(1f, 1f, 1f, 1f);
			print ("Vanish duration finished, but still on CD");
		}

		//Vanish Cooldown graphic
		if (Time.time <= vanishOffCooldown) {
			VanishCD.fillAmount = 1 - (Time.time / vanishOffCooldown);
			print ((Time.time - vanishOffCooldown)/20);
		} 
		else 
		{
			VanishCD.fillAmount = 0.0f;
		}

		//player attacking when pressing the attack button
		if (Input.GetAxisRaw ("Fire1") > 0) 
		{//Fire1 is Mouse1
			cardAttack();
		}

		//Vanish skill
		if (Input.GetKey("1")) 
		{
			skillVanish();
		}
			
	}

	//Good for physics
	void FixedUpdate () 
	{
		//check if player is grounded.Takes care of falling. 
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
		myAnim.SetBool("isGrounded", grounded);
		myAnim.SetFloat("verticleSpeed", playerRB.velocity.y);

		float move = Input.GetAxis("Horizontal");//Axis = predefined value in Unity
		myAnim.SetFloat("speed",Mathf.Abs(move));//pass in absolute value of move.
		playerRB.velocity = new Vector2(move*maxSpeed, playerRB.velocity.y);//Only manipulating the X value.
		if (move > 0 && !facingRight) { //Player pressing D button.
			flip();
		} 
		else if (move < 0 && facingRight) //Player pressing A button
		{
			flip();
		}

		//Menu on Escape key press
		if (Time.time >= timestamp && (Input.GetKey("escape")))
		{
			menuActive = !menuActive;//Flip value on key press. Toggle ON/OFF
			escapeMenu.SetActive(menuActive);
			timestamp = Time.time + 0.5f;//0.5 = half a second.
		}
	}   

	void flip()//will flip the character sprite to face left or right
	{
		facingRight = !facingRight;//flip the value
		Vector3 theScale = transform.localScale;
		theScale.x *= -1; //Will flip sprite
		transform.localScale = theScale; //Apply the flip to the transform body
	}

	void cardAttack()
	{
		if (Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			if (facingRight) { //If player is facing right, create the original sprite
				//audio.PlayOneShot(cardAttackSound);
				Instantiate (projectileObject, spawnTip.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			} 
			else if (!facingRight) //If player is facing left, create sprite but flip 
			{
				//audio.PlayOneShot(cardAttackSound);
				Instantiate (projectileObject, spawnTip.position, Quaternion.Euler (new Vector3 (0, 0, 180f)));
			}
		}
	}

	void skillVanish()
	{
		if (Time.time > vanishOffCooldown) 
		{
			vanishOffCooldown = Time.time + vanishCooldown;//Sets the time when Vanish will be off cooldown
			//print ("Vanish!");
			isVanished = true;//The player is vanished
			transform.gameObject.tag = "Vanished";//Set the player tag to 'Vanished'
			VanishCD.fillAmount = 1.0f;
			durationOfVanish = Time.time + vanishDuration;//Sets a timer for 5 seconds (duration)
			playerSR.color = new Color(1f, 1f, 1f, 0.45f);// Set Player alpha to some %
		}

	}
}
