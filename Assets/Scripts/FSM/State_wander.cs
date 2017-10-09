using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class State_wander : State<AI> {
	private static State_wander instance;
	private static Vector3 wander_vector;
	private static bool newVector = true;

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
		
		if (newVector == true) {
			wanderTo();
		}
		if (wander_vector == owner.transform.position) {
			wanderTo();
		}

			
		wander (owner);
	}

	//Do before exiting state
	public override void ExitState(AI owner)
	{

	}

	//Update to a new state
	public override void UpdateState(AI owner)
	{



	}
	public void wanderTo() {
		wander_vector = new Vector3 (Random.Range (-24f, 24f), Random.Range (-24f, 24f), 0);
		newVector = false;
	}
	public void wander(AI owner){
		float timeToTarget = 3f;
		float maxSpeed = 15f * (1 / owner.transform.localScale.x);
		Rigidbody rb = owner.GetComponent<Rigidbody> ();
		Vector3 towards =  wander_vector - owner.transform.position;

		towards /= timeToTarget;
		if (towards.magnitude > maxSpeed) {
			towards.Normalize ();
			towards *= maxSpeed;
		}
		rb.velocity = towards;
		
	}
		

}