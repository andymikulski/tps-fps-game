using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialog : MonoBehaviour {
	TypingText text;

	void Start(){
		text = GetComponentInChildren<TypingText> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			text.SetText (new string[]{ "HELLO", "This is a test.", "Do not be alarmed." });
			text.StartTyping ();
		} else if (other.gameObject.GetComponent<PickupFloatSpin>() != null) {
			PickupFloatSpin pickup = other.gameObject.GetComponent<PickupFloatSpin> ();

			text.SetText (new string[]{ "WELL HELLO THERE MISTER " + pickup.ItemPrefab.GetComponent<InventoryItem> ().name.ToUpper() });
			text.StartTyping ();
		}
	}
}
