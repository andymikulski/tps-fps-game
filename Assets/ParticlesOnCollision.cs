using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesOnCollision : MonoBehaviour {
	public GameObject[] particles;
	public string[] TagsToIgnore;
	public float RequiredStrength = 2f;

	void OnCollisionEnter(Collision collision)
	{
		if (Mathf.Abs(collision.relativeVelocity.magnitude) > RequiredStrength) {
			bool isIgnoredTag = false;
			foreach (string ignoreTag in TagsToIgnore)
			{
				isIgnoredTag = isIgnoredTag || collision.collider.gameObject.tag.Contains(ignoreTag);
			}

			if (isIgnoredTag) {
				return;
			}

			foreach (GameObject system in particles) {
				GameObject newParts = Instantiate (system, transform.position, transform.rotation) as GameObject;
				newParts.GetComponent<ParticleSystem> ().Play ();
			}
		}
	}
}
