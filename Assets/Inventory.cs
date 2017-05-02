using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	public Dictionary<string, InventoryItem> items = new Dictionary<string, InventoryItem>();

	public void AddItem (InventoryItem item){
		// No key = we are adding this to the inventory
		if (!items.ContainsKey (item.name)) {
			items.Add (item.name, item);
		} else {
		// Key exists = we need to update the quantity
			items [item.name].quantity += item.quantity;
		}
		Debug.Log ("added " + item.name + " - " + items[item.name].quantity);
	}

	public InventoryItem GetItem(string name) {
		InventoryItem foundItem;
		items.TryGetValue (name, out foundItem);

		return foundItem;
	}
}
