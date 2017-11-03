using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;//What the camera will be following
	public float smoothing;//The dampening effect on the camera. How quickly the camera begins to follow

	Vector3 offset;//Distance from the player object to the camera
	float lowestY; //The lowest the camera can go in the Y direction

	// Use this for initialization
	void Start () 
	{
		offset = transform.position - target.position;
		lowestY = transform.position.y;//This is where the camera is looking in the Unity window.
	}

	void FixedUpdate () 
	{
		Vector3 targetCameraPosition = target.position + offset; //Where the camera always wants to be located
		transform.position = Vector3.Lerp(transform.position, targetCameraPosition, smoothing * Time.deltaTime); //Smooth motion. Time.deltaTime = Difference in time from the last frame.
		if (transform.position.y < lowestY) 
		{
			transform.position = new Vector3 (transform.position.x, lowestY, transform.position.z);//If the camera goes below lowestY, reposition the camera.
		}
	}


}
