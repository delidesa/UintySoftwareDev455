/*
 * 
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour {

	public float damage;//Amount of damage
	public float damageRate;//how often object can do damage
	public float pushBackForce; //force of push back
	public bool canAttackVanished=false;
	float nextDamage;

	// Use this for initialization
	void Start () 
	{
		nextDamage = 0f;//0 means character can be damaged immediately

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player" && nextDamage < Time.time) 
		{
			playerHealth thePlayer = other.gameObject.GetComponent<playerHealth>();//reference to player health script
			thePlayer.addDamage(damage);
			nextDamage = Time.time + damageRate;//Current time + ___
			pushBack(other.transform);
		}
	}

	void pushBack(Transform pushedObject)
	{
		Vector2 pushDirection = new Vector2(0, pushedObject.position.y-transform.position.y).normalized; //Vector direction is opposite of object.
		pushDirection *= pushBackForce;//Give force greater than 1
		Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();//Find RB of pushed object
		pushRB.velocity = Vector2.zero;//Set all forces of RB to 0.
		pushRB.AddForce (pushDirection, ForceMode2D.Impulse);
	}
}
