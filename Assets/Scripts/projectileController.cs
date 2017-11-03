using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

	Rigidbody2D rb;//Reference to RB on the script object.
	public float projectileSpeed; //Ajust the speed of the projectile.

	// When object first comes to life
	void Awake () 
	{
		rb = GetComponent<Rigidbody2D>();
		//As soon as instatiated shoot projectile
		if (transform.localRotation.z > 0) 
		{
			rb.AddForce (new Vector2 (-1, 0) * projectileSpeed, ForceMode2D.Impulse); //-X direction, straight line away from character. Impulse is similar to a rocket explosion.
		} 
		else 
		{
			rb.AddForce(new Vector2(1,0) * projectileSpeed, ForceMode2D.Impulse); //X direction, straight line away from character. Impulse is similar to a rocket explosion.
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void removeForce()
	{
		rb.velocity = new Vector2(0, 0);
	}
}
