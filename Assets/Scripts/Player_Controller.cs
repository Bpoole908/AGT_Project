using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{


	public float minSpeed, maxSpeed;
	public float speed;
	private Rigidbody rb;
	private Transform tr;
	[HideInInspector]public AudioSource audio;
	private float oldSize;
	public float energy;


	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		tr = GetComponent<Transform> ();
		audio = GetComponent<AudioSource> ();
		oldSize = 0.0f;
	}


	void FixedUpdate ()
	{
		float moveHor = Input.GetAxis ("Horizontal");
		float moveVer = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHor, moveVer, 0.0f);

		//need to figure out better algorithm here. this one seems a bit harsh
		speed = (70 - GetComponent<Entity> ().size);

		if (speed > maxSpeed)
			speed = maxSpeed;
		else if (speed < minSpeed)
			speed = minSpeed;

		tr.Translate (movement * speed / 400); 
	}

	void Update ()
	{

		if (Input.GetKey (KeyCode.Space)) {


		}

			

	}

}
