using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorb_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print ("start");
	}

	//not sure if this is the right method. need to chnage it if we use the 2d one
	void onCollisionEnter2d(Collision col){

		print (col.gameObject.GetComponent<Entity>().test);

	}



	
	// Update is called once per frame
	void Update () {
		
	}
}
