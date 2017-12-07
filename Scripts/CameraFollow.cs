using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	//TODO: Get camera to not follow player's jump height. Makes jumping hard

	public Transform target;//What the camera will be following
	public float smoothing;//The dampening effect on the camera. How quickly the camera begins to follow

	Vector3 offset;//Distance from the player object to the camera
	float lowestY; //The lowest the camera can go in the Y direction
	float leftXLimit=0.05f;
	float rightXLimit=0.05f;
	float highestY= 1.05f;

	// Use this for initialization
	void Start () 
	{
		offset = transform.position - target.position;
		lowestY = transform.position.y;//This is where the camera is looking in the Unity window.
	}

	void FixedUpdate ()
	{

			Vector3 targetCameraPosition = target.position + offset; //Where the camera always wants to be located
			transform.position = Vector3.Lerp (transform.position, targetCameraPosition, smoothing * Time.deltaTime); //Smooth motion. Time.deltaTime = Difference in time from the last frame.
			if (transform.position.x < leftXLimit) {
				//Debug.Log ("Left Test");
				transform.position = new Vector3 (leftXLimit, transform.position.y, transform.position.z);//If the camera goes below lowestY, reposition the camera.
			}
			if (transform.position.x > rightXLimit) {
				//Debug.Log ("Right Test");
				transform.position = new Vector3 (rightXLimit, transform.position.y, transform.position.z);//If the camera goes below lowestY, reposition the camera.
			}
			if (transform.position.y < lowestY) {
				//Debug.Log ("Below Test");
				transform.position = new Vector3 (transform.position.x, lowestY, transform.position.z);//If the camera goes below lowestY, reposition the camera.
			}

			if (transform.position.y > highestY) {
				//Debug.Log ("Clamp Test");
				transform.position = new Vector3 (transform.position.x, highestY, transform.position.z);//If the camera goes below ceilingLimit, clamp the camera.
			}
	}


}
