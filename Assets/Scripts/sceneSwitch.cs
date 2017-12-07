using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Scene loader

public class sceneSwitch : MonoBehaviour 
{
	public string sceneToLoad;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			//Debug.Log ("Load Scene...");
			SceneManager.LoadScene(sceneToLoad);
		}
	}

}
