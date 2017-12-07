using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

	Rigidbody2D rb;//Reference to RB on the script object.
	public float projectileSpeed; //Ajust the speed of the projectile.

	public bool shootUp = false;
	public bool shootDown = false;
	public bool shootLeft = false;
	public bool shootRight = false;

	// When object first comes to life
	void Awake () 
	{
		rb = GetComponent<Rigidbody2D>();
		//As soon as instatiated shoot projectile

			//Trap Projectiles
		if (shootLeft == true) 
		{
			rb.AddForce (new Vector2 (-1, 0) * projectileSpeed, ForceMode2D.Impulse); //-X direction, straight line away from character. Impulse is similar to a rocket explosion.
		} 
		else if (shootRight == true) 
		{
			rb.AddForce (new Vector2 (1, 0) * projectileSpeed, ForceMode2D.Impulse); //X direction, straight line away from character. Impulse is similar to a rocket explosion.

		} 
		else if (shootDown == true) 
		{
			rb.AddForce (new Vector2 (0, -1) * projectileSpeed, ForceMode2D.Impulse); //Y direction, straight down
		} 
		else if (shootUp == true) 
		{
			rb.AddForce (new Vector2 (0, 1) * projectileSpeed, ForceMode2D.Impulse); //Y direction, straight up
		} 
		//Player projectile
		else 
		{
			if (transform.localRotation.z > 0) 
			{
				rb.AddForce (new Vector2 (-1, 0) * projectileSpeed, ForceMode2D.Impulse); //-X direction, straight line away from character. Impulse is similar to a rocket explosion.
			} 
			else 
			{
				rb.AddForce (new Vector2 (1, 0) * projectileSpeed, ForceMode2D.Impulse); //X direction, straight line away from character. Impulse is similar to a rocket explosion.
			}
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
