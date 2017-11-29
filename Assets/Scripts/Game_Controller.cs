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
	public Text gameOverText;
	public GameObject restartButton;
	private bool incTimer;
	public Text timerText;
	public Text milestoneText;
	public Text highScoresText;
	public string[] sizeMilestones;
	[HideInInspector]public bool mainMenuActive;
	private float menuTimeOffset;



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
		//gameOverText.SetActive(false);
		restartButton.SetActive(false);
		incTimer = true;
		restartButton.GetComponent<CanvasGroup>().alpha = 0;
		gameOverText.CrossFadeAlpha(0.0f, 0.01f, false);

	}

	void Start () {
		planeSize = plane.transform.localScale;
		mainMenuActive = true;
		menuTimeOffset = 0f;
		UpdateHighScoreDisplay ();



		//print (PlayerPrefs.GetInt ("highscore"));


	}

	void Update () {
		planeSize = plane.transform.localScale;
		if(mainMenuActive)
			menuTimeOffset = Time.timeSinceLevelLoad;
		if(incTimer && !mainMenuActive)
			UpdateTimer ();

		if (Input.GetKey (KeyCode.Escape))
			Restart ();

	}

	public void StartGame(){
		mainMenuActive = false;
	}
	public void ExitGame(){
		Application.Quit ();
		print ("test");
	}

	public void GameOver(){

		//code for what follows a game over
		print("Game Over");
		incTimer = false;
		UpdateHighScores ();


		//gameOverText.SetActive(true);
		restartButton.SetActive(true);
		//restartButton.GetComponent<CanvasGroup>().alpha = 1;
		StartCoroutine (WaitAndFadeText(1,gameOverText));
	}
	public void UpdateHighScores(){

		string label = "";

		for (int i = 1; i <= 3; i++) {

			if (i == 1)
				label = "st";
			else if (i == 2)
				label = "nd";
			else if(i == 3)
				label = "rd";
				

			if((int)(Time.timeSinceLevelLoad - menuTimeOffset) > PlayerPrefs.GetInt (i + label + ": "))
				PlayerPrefs.SetInt (i + label + ": ", (int)(Time.timeSinceLevelLoad - menuTimeOffset));			
		}
			

	}
	public void UpdateHighScoreDisplay(){
		string label = "";
		for (int i = 1; i <= 3; i++) {

			if (i == 1)
				label = "st";
			else if (i == 2)
				label = "nd";
			else if(i == 3)
				label = "rd";


			if (PlayerPrefs.GetInt (i + label + ": ") == null)
				PlayerPrefs.SetInt (i + label + ": ", 0);
				
			highScoresText.text += i + label + ": " + PlayerPrefs.GetInt (i + label + ": ") + "\n\n";	

		}
		
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
	public void FadeTextIn(Text t){
		t.CrossFadeAlpha(1.0f, 3.0f, false);
	}


	/// <summary>
	/// Wait for s seconds and then fade in text t.
	/// </summary>
	/// <returns>The and fade text.</returns>
	/// <param name="s">Seconds to wait</param>
	/// <param name="t">Text to fade in</param>
	IEnumerator WaitAndFadeText(int s, Text t)
	{

		yield return new WaitForSeconds(s);
		FadeTextIn (t);
		StartCoroutine(WaitAndFadeButton (2,restartButton));

	}
	IEnumerator WaitAndFadeButton(int s, GameObject t)
	{

		yield return new WaitForSeconds(s);

		StartCoroutine (FadeButtonIn ());
	}

	IEnumerator FadeButtonIn()
	{
		float time = 1f;
		while(restartButton.GetComponent<CanvasGroup>().alpha < 1)
		{
			restartButton.GetComponent<CanvasGroup>().alpha += Time.deltaTime / time;
			yield return null;
		}
	}

	void UpdateTimer(){
		string s = "Time: " + (Time.timeSinceLevelLoad - menuTimeOffset);
		s = s.Split ('.') [0];
		timerText.text =s;
	}

	public void UpdateMilestoneUI(int step){
		milestoneText.text = sizeMilestones [step];
	}

	public void Win(){
		print ("Game win");
		gameOverText.text = "You win!";
		incTimer = false;
		//gameOverText.SetActive(true);
		restartButton.SetActive(true);
		//restartButton.GetComponent<CanvasGroup>().alpha = 1;
		StartCoroutine (WaitAndFadeText(1,gameOverText));
	}
}
