/*
 * 
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Access UI

public class playerHealth : MonoBehaviour {

	public float maxPlayerHealth;
	public GameObject deathFX;
	float currentPlayerHealth;
	public Transform spawnPoint;//The spawn/respawn point of the level.
	public GameObject deathMenu;
	playerController thePlayer;

	//HUD variables
	public Slider healthSlider;//Reference to GUI slider.
	public Image damageScreen;
	bool damaged = false;
	Color damagedColor = new Color(0f,0f,0f,0.45f);//Alpha set to 50%
	float smoothColor = 5f;

	public AudioClip playerHurt;
	AudioSource playerAudioSource;

	// Use this for initialization
	void Start () 
	{
		currentPlayerHealth = maxPlayerHealth;
		thePlayer= GetComponent<playerController>();

		playerAudioSource = GetComponent<AudioSource>();

		//HUD initialization
		healthSlider.maxValue = maxPlayerHealth;
		healthSlider.value = maxPlayerHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (damaged) //flash screen with damageIndicator image
		{ 
			damageScreen.color=damagedColor;//Change alpha from 0 to __
		} 
		else 
		{
			damageScreen.color = Color.Lerp (damageScreen.color, Color.clear,smoothColor*Time.deltaTime);//color.clear=(0,0,0,0)
		}
		damaged = false;
	}

	public void addHealth(float healthAmount)//Added health function
	{
		currentPlayerHealth += healthAmount;
		if (currentPlayerHealth > maxPlayerHealth) //Adjust HP to max amount if it goes over the limit
		{
			currentPlayerHealth = maxPlayerHealth;
		}
		healthSlider.value = currentPlayerHealth;//Update Health Bar

	}

	public void addDamage(float damage)
	{
		if (damage <= 0) 
		{
			return;
		}
		currentPlayerHealth = currentPlayerHealth - damage;

		playerAudioSource.clip = playerHurt;
		playerAudioSource.Play();

		healthSlider.value = currentPlayerHealth;
		damaged = true;

		if (currentPlayerHealth <= 0) 
		{
			makeDead ();
		}
	}

	public void makeDead()
	{
		Instantiate(deathFX, transform.position, transform.rotation);
		Destroy(gameObject);
		//Died - Popup Death Screen
		deathMenu.SetActive(true);

		//Respawn the player.
		//thePlayer.transform.position = spawnPoint.transform.position;
		//currentPlayerHealth = maxPlayerHealth;//Reset Health
		//healthSlider.value = currentPlayerHealth;//Update Health Bar
	}
}
