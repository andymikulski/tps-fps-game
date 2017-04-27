using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGI : MonoBehaviour {
	void Update () {
		DynamicGI.UpdateEnvironment ();
	}
}
