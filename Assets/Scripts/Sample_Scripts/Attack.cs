using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[System.Serializable] 
public class Attack: MonoBehaviour {

	//this class defines an attack or the damage made by that attack of eather the player or the enemy
	[SerializeField]
	private float attackdamage; //this will be used by the hero and the enemy
    private float attack_Bonus;

    [SerializeField]
    enum Attack_type {
    	FIRE, WIND, SPECIAL_MODE
    }
	//we can use this private float and can set and get its value in another class
	public float Attackdamage
	{ 
		get { return this.attackdamage; }
		set { attackdamage = value; }
	}
	//this will allow the user to assing the scripts to enemies and heroes
	public float Attack_Bonus
	{ 
		get { return this.attack_Bonus; }
		set { attack_Bonus = value; }
	}
}
