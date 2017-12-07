using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiArcher : MonoBehaviour {

	Animator theArcher;
	public Transform arrowTip;
	public GameObject projectileObject;

	// Use this for initialization
	void Start () 
	{
		theArcher = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			theArcher.SetBool ("isAttacking", true);
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{

		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			theArcher.SetBool ("isAttacking", false);
		}
	}

	public void shootArrow()
	{
		//if facing right
		Instantiate (projectileObject, arrowTip.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
		//if facing left

	}
}
