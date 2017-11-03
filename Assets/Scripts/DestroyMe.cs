using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

	public float destoryTime;

	void Awake () 
	{
		Destroy (gameObject, destoryTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
