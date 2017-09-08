using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorb_Script : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}

	//not sure if this is the right method. need to chnage it if we use the 2d one
	void OnCollisionEnter(Collision col) {

		float thisSize = this.gameObject.GetComponent<Entity>().size;
		float colSize = col.gameObject.GetComponent<Entity> ().size;

		if (thisSize < colSize) {
			Destroy (this.gameObject);
			StartCoroutine(this.sizeInc());
		} else if (thisSize > colSize) {
			Destroy (col.gameObject);
			StartCoroutine(this.sizeInc());
		} else {
			//what should we do if they're the same size?
		}
	}
	// Update is called once per frame
	void Update () {

	}

	IEnumerator sizeInc(){
		float deltaScale = 0.5f;
		float rateOfChange = .01f;
		Vector3 target = transform.localScale;
		target += new Vector3 (deltaScale, deltaScale, deltaScale);

		while (transform.localScale.x < target.x) {
			transform.localScale = Vector3.Lerp (transform.localScale, target, rateOfChange);
			yield return null;
		}

	}
}
