using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class AI : MonoBehaviour {
	public bool switchState = false;
	public float gameTimer;
	public int seconds = 0;
	public GameObject player;
	public GameObject enemy;
	public Transform obj;
	private Vector3 playerOffSet;

	public StateMachine<AI> stateMachine { get; set; }

	private void Start()
	{
		stateMachine = new StateMachine<AI> (this);
		stateMachine.ChangeState (State_idle.Instance);
		gameTimer = Time.time;
	}
	private void Update()
	{
		player =  GameObject.FindWithTag("Player");
		obj = this.transform;
		playerOffSet = player.transform.position - this.transform.position;
		Debug.Log (playerOffSet.sqrMagnitude);
		if (playerOffSet.sqrMagnitude < 10)
			stateMachine.ChangeState (State_escape.Instance);
		else
			stateMachine.ChangeState (State_idle.Instance);
	}

	public void escape(){
		Vector3 og = this.transform.position;
		//this.transform.position = og + new Vector3 (1, 1, 0);
		this.transform.position = Vector3.Lerp (this.transform.position, player.transform.position + og, .001f);
	}
}
