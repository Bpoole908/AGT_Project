using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour {

	//starts at 100x100
	public Vector3 planeSize;
	public GameObject plane;


	// Use this for initialization
	void Start () {
		planeSize = plane.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
