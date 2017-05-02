using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParticlesOnCollision : MonoBehaviour {
	public GameObject[] particles;
	public string[] TagsToIgnore;
	public float RequiredStrength = 2f;

	void OnCollisionEnter(Collision collision)
	{
		if (Mathf.Abs(collision.relativeVelocity.magnitude) > RequiredStrength) {
			if (TagsToIgnore.Any (collision.collider.gameObject.tag.Contains)) {
				return;
			}

			foreach (GameObject system in particles) {
				GameObject newParts = Instantiate (system, transform.position, transform.rotation) as GameObject;
				newParts.GetComponent<ParticleSystem> ().Play ();
			}
		}
	}
}
