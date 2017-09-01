using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {


	public float speed;
	private Rigidbody rb;
	private Transform tr;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		tr = GetComponent<Transform>();
	}


	void FixedUpdate () {
		float moveHor = Input.GetAxis("Horizontal");
		float moveVer = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHor, moveVer, 0.0f);

		//rb.AddForce(movement * speed); 
		tr.Translate(movement * speed/400); 
	}
}
