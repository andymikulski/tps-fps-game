using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour {
	public Transform target;
	private NavMeshAgent agent;

	void Start () {
		agent = gameObject.AddComponent<NavMeshAgent> ();

		agent.speed = 2f;
		agent.stoppingDistance = 5f;
	}

	// Update is called once per frame
	void Update () {
		agent.SetDestination (target.position);
	}
}
