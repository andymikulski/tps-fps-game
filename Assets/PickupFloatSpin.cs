using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFloatSpin : MonoBehaviour {
	public GameObject ItemPrefab;
	public float spinSpeed = 1f;
	public float floatAmount = 1f;

	private GameObject item;
	private BoxCollider collide;

	public GameObject collectEffect;

	void Start () {
		item = Instantiate (ItemPrefab, gameObject.transform) as GameObject;

		collide = gameObject.GetComponent<BoxCollider> ();
		if (collide == null)
			collide = gameObject.AddComponent<BoxCollider> ();

		item.transform.localPosition = Vector3.zero;
		item.GetComponent<Rigidbody> ().isKinematic = true;
		item.GetComponent<Collider> ().enabled = false;

		collide.isTrigger = true;
	}

	// Update is called once per frame
	void Update () {
		item.transform.Rotate (Vector3.up, Time.deltaTime * spinSpeed);
		item.transform.Translate (Vector3.up * Mathf.Sin (Time.time) * (floatAmount / 2));
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(transform.position, 0.5f);
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			Inventory playerInventory = GameObject.Find("Player").GetComponent<Inventory> ();
			playerInventory.AddItem (new InventoryItem ("Donut", 1));

			if (collectEffect != null) {
				Instantiate (collectEffect, transform.position, Quaternion.identity);
			}

			Destroy (this);
			Destroy (gameObject);
		}
	}
}
