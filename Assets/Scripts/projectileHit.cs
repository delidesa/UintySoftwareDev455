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
		}
	}


	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
		{
			myPC.removeForce();//Called the RB and remove its force.
			Instantiate(explosionEffect, transform.position, transform.rotation);//transtion this script is attached to. Start there.
			Destroy(gameObject);
		}
	}
	// Update is called once per frame
	void Update () 
	{
		
	}
}
