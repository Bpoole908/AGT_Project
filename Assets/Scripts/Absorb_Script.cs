using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorb_Script : MonoBehaviour
{

	public GameObject background;
	// Use this for initialization
	void Start ()
	{
		
	}
		
	void OnCollisionEnter (Collision col)
	{

		float thisSize = this.gameObject.GetComponent<Entity> ().size;
		float colSize = col.gameObject.GetComponent<Entity> ().size;

		if (thisSize > colSize) {
			col.gameObject.SetActive(false);
			col.gameObject.GetComponent<Entity> ().removeSelfFromList ();
			StartCoroutine (this.sizeInc (this.transform, thisSize, colSize));

			//plays the consume sound only if it was the player that got bigger
			if (this.gameObject.tag == "Player") {
				this.gameObject.GetComponent<Player_Controller> ().audio.Play ();
			}



		} else {
			//what should we do if they're the same size?
		}
	}
	// Update is called once per frame
	void Update ()
	{

	}

	IEnumerator sizeInc (Transform source, float bigger, float smaller)
	{
		float deltaScale = (smaller/bigger) + 1;
		float rateOfChange = .1f;
		Vector3 target = source.localScale + new Vector3 (deltaScale, deltaScale, deltaScale);
		Vector3 backgroundTarget = background.transform.localScale + new Vector3 (deltaScale, deltaScale, deltaScale);
		this.gameObject.GetComponent<Light> ().range += deltaScale*2;


		while (source.localScale.x < target.x) {
			source.localScale = Vector3.Lerp (source.localScale, target, rateOfChange);

			if (this.gameObject.tag == "Player") {
				background.transform.localScale = Vector3.Lerp (background.transform.localScale, backgroundTarget, rateOfChange);
			}


			yield return null;
		}

	}

}
