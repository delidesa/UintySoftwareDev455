/*Enemy Health
 * 
 * 
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Access to UI

public class enemyHealth : MonoBehaviour {

	public float enemyMaxHealth;//Max health an enemy can have.
	float enemyCurrentHealth;//The current health of the enemy.

	public GameObject enemyDeathParticles;
	public Slider enemyHealthSlider;//Drag and drop slider

	public bool canDrop;
	public GameObject pickup1;//The drop

	// Use this for initialization
	void Start () 
	{
		enemyCurrentHealth = enemyMaxHealth;
		enemyHealthSlider.maxValue = enemyCurrentHealth;
		enemyHealthSlider.value = enemyCurrentHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void AddDamage(float damage)//Change the current health. Removes HP.
	{
		enemyHealthSlider.gameObject.SetActive(true);//Turn the Health Bar ON.
		enemyCurrentHealth = enemyCurrentHealth - damage;
		enemyHealthSlider.value = enemyCurrentHealth;//update the Health Bar (Slider)
		if (enemyCurrentHealth <= 0) 
		{
			makeDead();
		}
	}

	void makeDead()
	{
		Destroy(gameObject);
		Instantiate(enemyDeathParticles, transform.position, transform.rotation);//particle bloood
		if (canDrop) //If canDrop = true enemy can drop items
		{
			Instantiate(pickup1, transform.position, transform.rotation);//Spawn a dropable item
		}
	}
}
