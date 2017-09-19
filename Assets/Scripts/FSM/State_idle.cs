using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class State_idle : State<AI> {
	private static State_idle instance;

	private State_idle()
	{
		if(instance != null)
			return;

		instance = this;
	}

	public static State_idle Instance
	{
		get 
		{
			if(instance == null)
				new State_idle();
			return instance;
		}

	}

	public override void EnterState(AI owner, MonoBehaviour myMono)
	{
		Debug.Log("Idle");
	}

	public override void ExitState(AI owner)
	{

	}

	public override void UpdateState(AI owner)
	{


	}
		
		
}
