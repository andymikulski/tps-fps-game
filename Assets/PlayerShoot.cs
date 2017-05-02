using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	public GameObject[] projectiles;
	private int currentProjectile = 0;
	public Transform emitter;

	public float OutwardForce = 250f;
	public float UpwardForce = 15f;

	public bool UseRandomProjectileOrder = false;
	public bool UseRandomProjectileRotation = false;

	GameObject GetNextProjectile() {
		if (UseRandomProjectileOrder) {
			return projectiles [Random.Range (0, projectiles.Length)];
		}

		currentProjectile += 1;
		if (currentProjectile >= projectiles.Length) {
			currentProjectile = 0;
		}

		return projectiles [currentProjectile];
	}

	void Update () {
		if (Input.GetMouseButtonDown(0) || (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift))) {
			CreateAndShoot ();
		}
	}

	void CreateAndShoot() {
		Quaternion newRot = emitter.transform.rotation;

		if (UseRandomProjectileRotation) {
			newRot = Random.rotation;
		}

		GameObject newBall = Instantiate (GetNextProjectile(), emitter.transform.position, newRot) as GameObject;
		newBall.tag = "Projectile";
		Rigidbody rb = newBall.GetComponent<Rigidbody> ();

		if (!rb) {
			newBall.AddComponent<Rigidbody> ();
		}

		rb.AddForce ((emitter.transform.forward * OutwardForce) + (emitter.transform.up * UpwardForce));
	}
}
