using UnityEngine;

public class TimeManager : MonoBehaviour {

	public float slowdownFactor = 0.05f;
	public float slowdownLength = 2f;

	// Use this for initialization
	void Start () {
		Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
		Time.timeScale = Mathf.Clamp (Time.timeScale, 0f, 1f);

		Time.fixedDeltaTime += (1f / slowdownLength) * Time.fixedUnscaledDeltaTime;
		Time.fixedDeltaTime = Mathf.Clamp (Time.fixedDeltaTime, 0f, 1f);
	}
	
	public void DoSlowMotion(){
		Time.timeScale = slowdownFactor;
		Time.fixedDeltaTime = Time.timeScale * .02f;
	}
}