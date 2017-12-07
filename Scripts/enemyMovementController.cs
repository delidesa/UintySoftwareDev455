using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour {

	public float enemySpeed;

	Animator enemyAnimator;

	//Which way is AI facing
	public GameObject enemySprite;
	bool canFlip = true;//if Ai is charging, it cant flip
	bool facingRight = false;
	float flipCoolDown = 5f; //Flip cooldown defined
	float nextFlipChance = 0f;//Flip time

	//Attacking
	public float chargeTime;//WIll charge x seconds after entering the trigger
	float startChargeTime;
	bool charging;
	Rigidbody2D enemyRB;//Reference to the rigidbody, used to manipulate velocity etc

	// Use this for initialization
	void Start () 
	{
		enemyAnimator = GetComponentInChildren<Animator>();
		enemyRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time > nextFlipChance) 
		{
			if (Random.Range (0, 10) >= 5) 
			{
				flipFacing();
			}
			nextFlipChance = Time.time + flipCoolDown;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if (facingRight && other.transform.position.x < transform.position.x) {//check where player is
				flipFacing ();
			} 
			else if (!facingRight && other.transform.position.x > transform.position.x) //if enemy is on the other side
			{
				flipFacing();
			}
			canFlip = false; //once facing the right way, AI cant flip
			charging = true;//Start attacking when facing correct way.
			startChargeTime = Time.time + chargeTime; //Charge after certain amount of time.
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if (startChargeTime < Time.time) 
			{
				if (!facingRight) {
					enemyRB.AddForce (new Vector2 (-1, 0) * enemySpeed);
				} 
				else 
				{
					enemyRB.AddForce (new Vector2 (1, 0) * enemySpeed);
				}
				enemyAnimator.SetBool ("isCharging", charging);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			canFlip = true;
			charging = false;
			enemyRB.velocity = new Vector2(0f, 0f);
			enemyAnimator.SetBool("isCharging", charging);
		}
	}

	void flipFacing()
	{
		if (!canFlip) 
		{
			return;
		}
		float facingX = enemySprite.transform.localScale.x;
		facingX *= -1f;
		enemySprite.transform.localScale = new Vector3(facingX, enemySprite.transform.localScale.y, enemySprite.transform.localScale.z);
		facingRight = !facingRight;
	}
}
