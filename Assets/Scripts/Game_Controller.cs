using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour {

	public static Game_Controller instance = null;
	//starts at 100x100
	public Vector3 planeSize;
	public GameObject plane;


	void Awake(){
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

	}

	// Use this for initialization
	void Start () {
		planeSize = plane.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		planeSize = plane.transform.localScale;
	}

	public void GameOver(){

		//code for what follows a game over
		print("Game Over");
	}

}
