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

	public override void EnterState(AI owner, MonoBehaviour myMono)
	{
		Debug.Log ("chase");
		owner.escape ();
	}

	public override void ExitState(AI owner)
	{

	}

	public override void UpdateState(AI owner)
	{

			

	}

}
