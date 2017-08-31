using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorb_Script : MonoBehaviour {

	private float deltaScale = 0.5f;
	// Use this for initialization
	void Start () {
		
	}

	//not sure if this is the right method. need to chnage it if we use the 2d one
	void OnCollisionEnter2D(Collision2D col){

		float thisSize = this.gameObject.GetComponent<Entity>().size;
		float colSize = col.gameObject.GetComponent<Entity> ().size;



		if (thisSize < colSize) {
			Destroy (this.gameObject);
			col.transform.localScale += new Vector3 (deltaScale, deltaScale, 0.0f);
		} else if (thisSize > colSize) {
			Destroy (col.gameObject);
			this.transform.localScale += new Vector3 (deltaScale, deltaScale, 0.0f);
		} else {
			//what should we do if they're the same size?
		}
	}



	
	// Update is called once per frame
	void Update () {
		
	}
}
