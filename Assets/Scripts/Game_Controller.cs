using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game_Controller : MonoBehaviour {

	public static Game_Controller instance = null;
	//starts at 100x100
	public Vector3 planeSize;
	public GameObject plane;
	public Slider energyBar;
	public GameObject energyBarFill;


	void Awake(){
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene. Commented out because of errors when restarting game
		//DontDestroyOnLoad(gameObject);



	}

	void Start () {
		planeSize = plane.transform.localScale;
	}

	void Update () {
		planeSize = plane.transform.localScale;
	}

	public void GameOver(){

		//code for what follows a game over
		print("Game Over");
	}
	public void UpdateEnergyUI(float e){
		energyBar.value = e;
	}

	public void ChangeEnergyBarColor(Color c){
		energyBarFill.GetComponent<Image> ().color = c;
	}
	public void Restart(){
		
		SceneManager.LoadScene ("Game");
	}

}
