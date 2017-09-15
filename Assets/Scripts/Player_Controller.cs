using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{


	public float speed;
	private Rigidbody rb;
	private Transform tr;
	[HideInInspector]public AudioSource audio;
	private float oldSize;


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

		tr.Translate (movement * speed / 400); 
	}

	void Update ()
	{


	}

}
