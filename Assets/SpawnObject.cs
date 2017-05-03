using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {
	public PhysicMaterial physMaterial;

	public Material[] materials;

	void MakeSomething(){
		GameObject newObj = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		newObj.transform.parent = gameObject.transform;

		newObj.transform.localScale = Vector3.one / (Random.Range (-15f, 15f) + 1f);
		newObj.transform.position = Random.insideUnitSphere * 25f;

		newObj.AddComponent<Rigidbody> ();
		SphereCollider collider = newObj.GetComponent<SphereCollider> ();

		collider.sharedMaterial = physMaterial;

		newObj.gameObject.GetComponent<MeshRenderer> ().material = materials [Random.Range (0, materials.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.E)) {
			MakeSomething ();
			MakeSomething ();
			MakeSomething ();
			MakeSomething ();
			MakeSomething ();
		}
	}
}
