using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiArrowTrap : MonoBehaviour {

	//For the projectile
	public Transform gunTip;
	public GameObject projectileObject;
	float fireRate = 2.0f;
	float nextFire = 0f;

	//Projectile Directions
	public bool shootDown = false;
	public bool shootLeft = false;
	public bool shootRight = false;
	public bool shootUp = false;


	// Use this for initialization
	void Start () 
	{
		
	}
	

	void FixedUpdate () 
	{
		if (Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate (projectileObject, gunTip.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
		} 
	}
		

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if (Time.time > nextFire) 
			{
				nextFire = Time.time + fireRate;
				Instantiate (projectileObject, gunTip.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			} 

		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if (Time.time > nextFire) 
			{
				nextFire = Time.time + fireRate;
				Instantiate (projectileObject, gunTip.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			} 

		}
	}


}
