using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

	public Renderer rend;
	[HideInInspector] public float size;
	[HideInInspector] public float energy;

	// Use this for initialization
	void Start () {
		size = rend.bounds.size.x * rend.bounds.size.y;
	}

	// Update is called once per frame
	void Update () {
		
		size = rend.bounds.size.x * rend.bounds.size.y;

	}


}
