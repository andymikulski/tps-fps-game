using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOnAxes : MonoBehaviour {
	public Transform target;

	public float FollowSpeed = 1f;

	public bool FollowX = false;
	public bool FollowY = false;
	public bool FollowZ = false;

	private Vector3 offset;

	void Start () {
		offset = transform.position - target.transform.position;
	}

	void FixedUpdate () {
		float xPos = FollowX ? target.position.x : transform.position.x;
		float yPos = FollowY ? target.position.y : transform.position.y;
		float zPos = FollowZ ? target.position.z : transform.position.z;

		xPos += offset.x;
		yPos += offset.y;
		zPos += offset.z;

		Vector3 newPosition = Vector3.Slerp (transform.position, new Vector3 (xPos, yPos, zPos), Time.deltaTime * FollowSpeed);
		transform.position = newPosition;
	}
}
