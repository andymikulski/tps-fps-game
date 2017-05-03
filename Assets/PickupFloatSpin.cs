using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFloatSpin : MonoBehaviour {
	public GameObject ItemPrefab;
	public GameObject collectEffect;
	public float spinSpeed = 1f;
	public float floatAmount = 1f;
	public float shrinkAmount = 2f;

	private GameObject item;
	private BoxCollider collide;


	void Start () {
		item = Instantiate (ItemPrefab, gameObject.transform) as GameObject;
	
		float emptySize = 1.0f;
		MeshFilter mf = item.GetComponent<MeshFilter> ();

		if (mf != null) {
			Bounds bounds = mf.mesh.bounds;

			float max = bounds.extents.x * shrinkAmount;
			if (max < bounds.extents.y * shrinkAmount) 
				max = bounds.extents.y * shrinkAmount;
			if (max < bounds.extents.z * shrinkAmount)
				max = bounds.extents.z * shrinkAmount;

			float scale = (emptySize * 0.5f) / max;
			item.transform.localScale = new Vector3(scale, scale, scale);
		}

		collide = gameObject.GetComponent<BoxCollider> ();
		if (collide == null)
			collide = gameObject.AddComponent<BoxCollider> ();

		item.transform.localPosition = Vector3.zero;


		Rigidbody rb = item.GetComponent<Rigidbody> ();
		if (rb == null) {
			rb = item.AddComponent<Rigidbody> ();
		}
		rb.isKinematic = true;

		Collider existingCollider = item.GetComponent<Collider> ();
		if (existingCollider != null) {
			existingCollider.enabled = false;
		}

		collide.isTrigger = true;
	}

	// Update is called once per frame
	void Update () {
		item.transform.Rotate (Vector3.up, Time.deltaTime * spinSpeed);
		item.transform.Translate (Vector3.up * Mathf.Sin (Time.time) * (floatAmount / 2));
		collide.transform.Translate (Vector3.up * Mathf.Sin (Time.time) * (floatAmount / 2));
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(transform.position, 0.5f);
	}

	void OnTriggerEnter(Collider other) {
		Inventory otherInventory = other.gameObject.GetComponentInParent<Inventory> ();

		if (otherInventory != null) {
			InventoryItem newItem = ItemPrefab.GetComponent<InventoryItem> ();

			if (newItem == null) {
				Debug.LogWarning ("No InventoryItem attached to " + ItemPrefab.name + ", can't be picked up!");
			} else {
				otherInventory.AddItem (newItem, 1);
			}

			if (collectEffect != null)
				Instantiate (collectEffect, transform.position, Quaternion.identity);

			Destroy (this);
			Destroy (gameObject);
		}
	}
}
