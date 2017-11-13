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
	public float boostEnergyMultiplier;
	public float maxEnergy;
	private bool boosting;
	public float energyLostPerSec;
	public ParticleSystem trail;
	public Color defaultColor = new Color(1f, 1f, .66f);
	public Color boostColor = new Color(1f, .5f, 0f);
	public Color energyBarColor = new Color(1f, .5f, 0f);
	public Color energyBarBoostColor = new Color(1f, 0f, 0f);
	private const float FRAME_RATE = 60f;


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

		energy -= change;
		energy = Mathf.Clamp(energy, 0, maxEnergy);
		Game_Controller.instance.UpdateEnergyUI (energy);
		//print (energy);
	}


	void FixedUpdate ()
	{
		float moveHor = Input.GetAxis ("Horizontal");
		float moveVer = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHor, moveVer, 0.0f);

		if (energy < 1)
			Game_Controller.instance.GameOver ();

		if (Input.GetKeyDown (KeyCode.Space)) {

			print("boosting");
			boosting = true;
			ParticleSystem.MainModule trailMain = trail.main;
			trailMain.startColor = boostColor;
			ParticleSystem.EmissionModule emission = trail.emission;
			emission.rateOverTime = 500;


		}

		if (Input.GetKeyUp (KeyCode.Space)) {

			print("stop boosting");
			boosting = false;
			ParticleSystem.MainModule trailMain = trail.main;
			trailMain.startColor = defaultColor;
			ParticleSystem.EmissionModule emission = trail.emission;
			emission.rateOverTime = 50;
		}





			Game_Controller.instance.ChangeEnergyBarColor (energyBarColor);
			speed = (70 - GetComponent<Entity> ().size);
			if (speed > maxSpeed)
				speed = maxSpeed;
			else if (speed < minSpeed)
				speed = minSpeed;
			updateEnergy (energyLostPerSec / FRAME_RATE); //Read this as energyLost per second, system is set to 60fps, do not alter the FRAME_RATE value. Adjust energyLostPerSec in the inspector.


		if(boosting){
			speed += boostSpeed;
			Game_Controller.instance.ChangeEnergyBarColor (energyBarBoostColor);
			updateEnergy (energyLostPerSec*boostEnergyMultiplier / FRAME_RATE); //Read this as energyLost per second, system is set to 60fps, do not alter the FRAME_RATE value. Adjust energyLostPerSec in the inspector.
		}

		//print (tr.position.x);

		tr.Translate (movement * speed / 400); 
		float boundsFactor = Game_Controller.instance.planeSize.x*10/2f*0.7f;
		if (tr.position.x < -1*boundsFactor || tr.position.x > boundsFactor || tr.position.y < -1*boundsFactor || tr.position.y > boundsFactor)
			tr.Translate(-1*movement * speed / 400);



	}

	void Update ()
	{


			


	}



}
