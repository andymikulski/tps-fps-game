using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	public GameObject snowball;
	public Transform emitter;

	public float OutwardForce = 250f;
	public float UpwardForce = 15f;

	void Update () {
		if (Input.GetMouseButton (0)) {
			GameObject newBall = Instantiate (snowball, emitter.transform.position, emitter.transform.rotation) as GameObject;
			Rigidbody rb = newBall.GetComponent<Rigidbody> ();

			rb.AddForce ((emitter.transform.forward * OutwardForce) + (emitter.transform.up * UpwardForce));
		}
	}
}
