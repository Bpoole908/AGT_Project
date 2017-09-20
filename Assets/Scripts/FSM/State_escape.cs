using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class State_escape : State<AI> {
	private static State_escape instance;

	private State_escape()
	{
		if(instance != null)
			return;

		instance = this;
	}

	public static State_escape Instance
	{
		get 
		{
			if(instance == null)
				instance = new State_escape();
			return instance;
		}

	}
	//Do upon entry of state
	//Meat of the code should go in EnterState for now
	public override void EnterState(AI owner)
	{
		Debug.Log ("ESCAPE!");
		escape(owner);

	}

	//Do before exiting state
	public override void ExitState(AI owner)
	{

	}

	//Update to a new state
	public override void UpdateState(AI owner)
	{
		
			

	}
	//Need better movement, needs to detect which direction it is being chased from and move accordingly
	public void escape(AI owner){
		Vector3 og =  new Vector3 (1, 1, 0);
		owner.transform.position = Vector3.Lerp (owner.transform.position, owner.transform.position + og, .01f);
	}


}
