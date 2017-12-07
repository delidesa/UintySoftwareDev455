//Adapted from https://answers.unity.com/questions/14279/make-an-object-move-from-point-a-to-point-b-then-b.html
//Adapted from https://youtu.be/O6wlIqe2lTA

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMover : MonoBehaviour 
{

	public Transform startPos;
	public Transform endPos;
	private Vector3 frometh;
	private Vector3 untoeth;
	public float secondsForOneLength = 9f;

	void Start()
	{
		frometh = startPos.position;
		untoeth = endPos.position;
	}

	void Update()
	{
		transform.position = Vector3.Lerp (frometh, untoeth, Mathf.SmoothStep (0f, 1f, Mathf.PingPong (Time.time / secondsForOneLength, 1f)));
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.tag == "Player") 
		{
			collision.collider.transform.SetParent(transform);
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{

		if (collision.gameObject.tag == "Player") 
		{
			collision.collider.transform.SetParent(null);
		}
	}
}
