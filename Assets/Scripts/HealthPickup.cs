using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO: If full health, pickup wont destroy.

public class HealthPickup : MonoBehaviour {

	public float HealthAmount;//The amount of HP the player will gain.

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "Player") 
		{
			playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth>();//Get the playerHealth component on the player
			thePlayerHealth.addHealth(HealthAmount);//Call the addHealth function
			Destroy(gameObject);
		}
	}
}
