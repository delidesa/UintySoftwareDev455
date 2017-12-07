using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileHit : MonoBehaviour {

	public float weaponDamage;
	projectileController myPC;
	public GameObject explosionEffect;

	void Awake () 
	{
		myPC = GetComponentInParent<projectileController>();

	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
		{
			myPC.removeForce();//Called the RB and remove its force.
			Instantiate(explosionEffect, transform.position, transform.rotation);//transtion this script is attached to. Start there.
			Destroy(gameObject);
			if(other.tag == "Enemy")
			{
				enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();//Reference to the enemies health
				hurtEnemy.AddDamage(weaponDamage);
			}
		}
		if (other.tag=="Player") 
		{
			myPC.removeForce();
			Destroy(gameObject);
			playerHealth hurtPlayer = other.gameObject.GetComponent<playerHealth>();
			hurtPlayer.addDamage(weaponDamage);
		}

	}


	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
		{
			myPC.removeForce();//Called the RB and remove its force.
			Instantiate(explosionEffect, transform.position, transform.rotation);//transtion this script is attached to. Start there.
			Destroy(gameObject);
			if(other.tag == "Enemy")
			{
				enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();//Reference to the enemies health
				hurtEnemy.AddDamage(weaponDamage);
			}
		}
	}
	// Update is called once per frame
	void Update () 
	{
		
	}
}
