using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

	public Renderer rend;
	[HideInInspector] public float size;
	GameObject gameController;

	// Use this for initialization
	void Start () {
		size = rend.bounds.size.x * rend.bounds.size.y;
		gameController = GameObject.Find ("GameController");
	}

	// Update is called once per frame
	void Update () {
		
		size = rend.bounds.size.x * rend.bounds.size.y;
		float boundsFactor = gameController.GetComponent<Game_Controller>().planeSize.x*10/2f*0.7f;

			if (transform.position.x < -1 * boundsFactor|| transform.position.x > boundsFactor)
				transform.position = new Vector3(-1*transform.position.x,transform.position.y, transform.position.z);
			else if(transform.position.y < -1*boundsFactor || transform.position.y > boundsFactor)
				transform.position = new Vector3(transform.position.x,-1*transform.position.y, transform.position.z);
		

	}

	public void removeSelfFromList(){
		GameObject.FindGameObjectWithTag ("Spawner").GetComponent<Spawner_Script> ().enemyList.Remove (this.gameObject);
	}


}
