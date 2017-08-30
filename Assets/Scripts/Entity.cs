using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

	[SerializeField] private bool isPlayer = false;
	public float speed;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHor = Input.GetAxis("Horizontal");
		float moveVer = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHor, moveVer, 0.0f);

		rb.AddForce(movement * speed);
	}
}
