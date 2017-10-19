using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class State_wander : State<AI> {
	private static State_wander instance;
	private Vector3 wanderTo;

	private State_wander()
	{
		if(instance != null)
			return;

		instance = this;
	}

	public static State_wander Instance
	{
		get 
		{
			if (instance == null) {
				new State_wander ();
			}
			return instance;
		}

	}

	//Do upon entry of state
	//Meat of the code should go in EnterState for now
	public override void EnterState(AI owner)
	{
		
		setWanderTo (owner);

	}

	//Do before exiting state
	public override void ExitState(AI owner)
	{

	}

	//Update to a new state
	public override void UpdateState(AI owner)
	{
		Debug.Log (wanderTo);
		if (owner.enemy != null) {
			Debug.Log ("switching to escape");
			owner.stateMachine.ChangeState (State_escape.Instance);
		}

		if (owner.transform.position == wanderTo) {
			setWanderTo (owner);
		}
		wander (owner);

	}
	public void setWanderTo(AI owner){
		//Plane Size
		float xbound = (owner.plane.transform.localScale.x - 2) * 10;
		float ybound = (owner.plane.transform.localScale.z - 2) * 10; //Hardcoded using z bc defalut plane is in XZ, but ours is rotated to be in XY
		Vector3 center = owner.plane.transform.position;

		float xPos = center.x + Random.Range (-xbound/2, xbound/2);
		float yPos = center.y + Random.Range (-ybound/2, ybound/2);

		wanderTo = new Vector3 (xPos, yPos, center.z);
	}

	public void wander(AI owner){
		float timeToTarget = 10f;
		float maxSpeed = 15f * (1 / owner.transform.localScale.x);
		Rigidbody rb = owner.GetComponent<Rigidbody> ();
		Vector3 towards =  wanderTo - owner.transform.position;

		towards /= timeToTarget;
		if (towards.magnitude > maxSpeed) {
			towards.Normalize ();
			towards *= maxSpeed;
		}
		rb.velocity = towards;
		
	}
		

}