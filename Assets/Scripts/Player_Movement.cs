using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {


	public float speed;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHor = Input.GetAxis("Horizontal");
		float moveVer = Input.GetAxis("Vertical");

		Vector2 movement = new Vector2(moveHor, moveVer);

		rb.AddForce(movement * speed);
	}
}
