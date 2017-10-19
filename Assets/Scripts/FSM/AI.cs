using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class AI : MonoBehaviour {
	[HideInInspector] public Transform enemy;
	public Vector3 wanderTo;
	public float stateTimer;
	public int seconds = 0;
	public float colliderRadius = 4f;
	public MonoBehaviour myMono;
	public GameObject plane;

	public StateMachine<AI> stateMachine { get; set; }

	private void Start()
	{
		stateMachine = new StateMachine<AI> (this);
		stateMachine.ChangeState (State_idle.Instance);
	}
	private void Update()
	{
		enemy = alertSphere (this.transform.position, colliderRadius);
		stateMachine.Update();
		Debug.Log (stateMachine.currentState);
	
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

			//If the largest thing is itself return null
			if (largest == this.transform) {
				return null;
			} else {
				return largest.transform;
			}
		}
		return null;
	}

	public void setWanderTo(AI owner){
		//Plane Size
		float xbound = (owner.plane.transform.localScale.x - 4) * 10; //Hardcoded using z bc defalut plane is in XZ, but ours is rotated to be in XY
		float ybound = (owner.plane.transform.localScale.z - 4) * 10; //Hardcoded using z bc defalut plane is in XZ, but ours is rotated to be in XY
		Vector3 center = owner.plane.transform.position;

		float xPos = center.x + Random.Range (-xbound/2, xbound/2);
		float yPos = center.y + Random.Range (-ybound/2, ybound/2);

		wanderTo = new Vector3 (xPos, yPos, center.z);
	}

}
