using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public Rigidbody PlayerBody;
	public Collider PlayerCollider;
	public float WalkSpeed = 1f;
	public float JumpStrength = 1f;

	public float UprightSpeed = 1f;

	public float MaxSpeed = 10f;

	// Update is called once per frame
	void FixedUpdate () {
		float shiftMultiplier = Input.GetKey (KeyCode.LeftShift) ? 2f : 1f;

		Debug.Log ("wtf " + Input.GetKey (KeyCode.LeftShift));

		float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * (WalkSpeed * shiftMultiplier);


//		if (Input.GetKey (KeyCode.W)) {
//			PlayerBody.AddForce (Vector3.forward * WalkSpeed);
//		}
//
//		if (Input.GetKey (KeyCode.A)) {
//			PlayerBody.AddForce (Vector3.left * WalkSpeed);
//		}
//
//		if (Input.GetKey (KeyCode.S)) {
//			PlayerBody.AddForce (Vector3.back * WalkSpeed);
//		}
//
//		if (Input.GetKey (KeyCode.D)) {
//			PlayerBody.AddForce (Vector3.right * WalkSpeed);
//		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			PlayerBody.AddExplosionForce (JumpStrength, PlayerBody.transform.position - Vector3.up, 10f);
		}
//
//		if(PlayerBody.velocity.sqrMagnitude > MaxSpeed)
//		{
//			PlayerBody.velocity *= 0.9999f;
//		}

//		if (Input.GetKey (KeyCode.LeftShift)) {
//			Quaternion newRot = new Quaternion (0f, 0f, 0f, PlayerBody.transform.rotation.w);
//			PlayerBody.transform.rotation = Quaternion.Slerp (PlayerBody.transform.rotation, newRot, Time.deltaTime * UprightSpeed);
//		} else {
			PlayerBody.transform.Rotate (0, x, 0);
			PlayerBody.transform.Translate (0, 0, z);
//		}
		
	}
}
