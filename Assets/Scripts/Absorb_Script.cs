using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorb_Script : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		
	}

	//not sure if this is the right method. need to chnage it if we use the 2d one
	void OnCollisionEnter (Collision col)
	{

		float thisSize = this.gameObject.GetComponent<Entity> ().size;
		float colSize = col.gameObject.GetComponent<Entity> ().size;

		if (thisSize < colSize) {
			Destroy (this.gameObject);
			StartCoroutine (col.gameObject.GetComponent<Absorb_Script> ().sizeInc (col.transform));
		} else if (thisSize > colSize) {
			Destroy (col.gameObject);
			StartCoroutine (this.sizeInc (this.transform));
		} else {
			//what should we do if they're the same size?
		}
	}
	// Update is called once per frame
	void Update ()
	{

	}

	IEnumerator sizeInc (Transform source)
	{
		float deltaScale = 0.5f;
		float rateOfChange = .1f;
		Vector3 target = source.localScale + new Vector3 (deltaScale, deltaScale, deltaScale);
		this.gameObject.GetComponent<Light> ().range += deltaScale;
		while (source.localScale.x < target.x) {
			source.localScale = Vector3.Lerp (source.localScale, target, rateOfChange);

			yield return null;
		}

	}

}
