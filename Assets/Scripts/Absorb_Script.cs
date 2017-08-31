using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorb_Script : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}

	//not sure if this is the right method. need to chnage it if we use the 2d one
	void OnCollisionEnter2D(Collision2D col){

		float thisSize = this.gameObject.GetComponent<Entity>().size;
		float colSize = col.gameObject.GetComponent<Entity> ().size;

		print ("This size: " + thisSize);
		print ("Col size: " + colSize);

	}



	
	// Update is called once per frame
	void Update () {
		
	}
}
