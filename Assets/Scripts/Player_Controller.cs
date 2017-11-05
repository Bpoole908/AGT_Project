using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Controller : MonoBehaviour
{
	/*
		Energy 10% max deter per sec.
		Consume increases relative to size of enemy.
		

	*/

	public float minSpeed, maxSpeed, boostSpeed;
	public float speed;
	private Rigidbody rb;
	private Transform tr;
	[HideInInspector]public AudioSource audio;
	private float oldSize;
	public float energy;
	public float maxEnergy;
	private bool boosting;
	public ParticleSystem trail;


	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		tr = GetComponent<Transform> ();
		audio = GetComponent<AudioSource> ();
		oldSize = 0.0f;
		boosting = false;
		energy = maxEnergy;
	}
	/// <summary>
	/// Updates the energy. Pass it a value for the percentage to update it by, positive or negative.
	/// </summary>
	/// <param name="change">Change.</param>

	public void updateEnergy(float change){

		energy += change;
		energy = Mathf.Clamp(energy, -1*Mathf.Infinity, maxEnergy);
		Game_Controller.instance.UpdateEnergyUI (energy);
		//print (energy);
	}


	void FixedUpdate ()
	{
		float moveHor = Input.GetAxis ("Horizontal");
		float moveVer = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHor, moveVer, 0.0f);




		if (!boosting) {

			speed = (70 - GetComponent<Entity> ().size);
			if (speed > maxSpeed)
				speed = maxSpeed;
			else if (speed < minSpeed)
				speed = minSpeed;
		} else {
			speed = (70 - GetComponent<Entity> ().size) + boostSpeed;
		}
		//print (tr.position.x);

		tr.Translate (movement * speed / 400); 
		float boundsFactor = Game_Controller.instance.planeSize.x*10/2f*0.7f;
		if (tr.position.x < -1*boundsFactor || tr.position.x > boundsFactor || tr.position.y < -1*boundsFactor || tr.position.y > boundsFactor)
			tr.Translate(-1*movement * speed / 400);

		updateEnergy (-1*(10.0f / 60.0f));

	}

	void Update ()
	{

		if (energy < 1)
			Game_Controller.instance.GameOver ();

		if (Input.GetKeyDown (KeyCode.Space)) {

			print("boosting");
			boosting = true;
			ParticleSystem.MainModule trailMain = trail.main;
			trailMain.startColor = Color.green;


		}

		if (Input.GetKeyUp (KeyCode.Space)) {

			print("stop boosting");
			boosting = false;
			ParticleSystem.MainModule trailMain = trail.main;
			trailMain.startColor = Color.white;
		}
			


	}



}
