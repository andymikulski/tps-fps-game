using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem {
	public string name = "Item";
	public float quantity = 0;

	public InventoryItem(string cName, float cQuantity) {
		this.name = cName;
		this.quantity = cQuantity;
	}
}
