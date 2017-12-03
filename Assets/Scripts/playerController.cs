using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	//movement variables
	public float maxSpeed;

	//jump variables
	bool grounded = false;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;

	bool facingRight;
	Rigidbody2D playerRB;
	Animator myAnim;

	//For the projectile
	public Transform gunTip;
	public GameObject projectileObject;
	float fireRate = 1.0f;
	float nextFire = 0f;

	//Audio
	//public AudioSource audio;
	//public AudioClip cardAttackSound;

	// Use this for initialization
	void Start () 
	{
		playerRB = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (grounded && Input.GetAxis("Jump") > 0) //Player can jump
		{
			grounded = false;
			myAnim.SetBool("isGrounded", grounded);
			playerRB.AddForce(new Vector2(0,jumpHeight));
		}

		//player attacking when pressing the attack button
		if (Input.GetAxisRaw ("Fire1") > 0) 
		{//Fire1 is Mouse1
			cardAttack();
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
	}

	void flip()//will flip the sprite to face left or right
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
				Instantiate (projectileObject, gunTip.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			} 
			else if (!facingRight) //If player is facing left, create sprite but flip 
			{
				//audio.PlayOneShot(cardAttackSound);
				Instantiate (projectileObject, gunTip.position, Quaternion.Euler (new Vector3 (0, 0, 180f)));
			}
		}
	}
}
