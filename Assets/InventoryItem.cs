using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {
	new public string name = "Item";
	public float quantity = 0;

	public InventoryItem(InventoryItem item) {
		name = item.name;
		quantity = item.quantity;
	}

	public InventoryItem(InventoryItem item, float count) {
		name = item.name;
		quantity = count;
	}
}
