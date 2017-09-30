using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class AI : MonoBehaviour {
	[HideInInspector] public Transform enemy;

	public StateMachine<AI> stateMachine { get; set; }

	private void Start()
	{
		stateMachine = new StateMachine<AI> (this);
		stateMachine.ChangeState (State_idle.Instance);
	}
	private void Update()
	{
		enemy = alertSphere (this.transform.position, 3f);

		if (enemy != null) {
				stateMachine.ChangeState (State_escape.Instance);
		} else {
				stateMachine.ChangeState (State_idle.Instance);
		}
	
	}


	/// <summary>
	/// Gets all colliders within a certain radius of itself.
	/// </summary>
	/// <returns>Largest objects transform or null if all other objects are smaller than its scale.</returns>
	/// <param name="center">Center of alert sphere.</param>
	/// <param name="radius">Radius or how lard the alert sphere is.</param>
	public Transform alertSphere(Vector3 center, float radius) {
		Transform largest = this.transform;
		Collider[] inAlterSphere = Physics.OverlapSphere (center, radius);

		if (inAlterSphere.Length > 0) {
			for (int i = 0; i < inAlterSphere.Length; i++) {

				if (inAlterSphere[i].GetComponent<Entity> ().size > largest.GetComponent<Entity> ().size) {
					largest = inAlterSphere [i].transform;
				}
			}

			if (largest == this.transform) {
				return null;
			} else {
				return largest.transform;
			}
		}
		return null;
	}

}
