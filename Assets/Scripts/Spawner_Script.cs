using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Script : MonoBehaviour {

	[HideInInspector] public List<GameObject> enemyList;
	public int maxEnemies;

	public float spawnRate;
	public float startDelay;
	public GameObject enemyPrefab;
	GameObject enemyClone;
	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("spawnEnemy", startDelay, spawnRate);
		enemyList = new List<GameObject> ();


	}
	
	// Update is called once per frame
	void Update () {




	}
	void spawnEnemy(){

		if (enemyList.Count < maxEnemies) {
			enemyClone = Instantiate (enemyPrefab, getRandomV3 (), Quaternion.identity) as GameObject;
			float scale = Random.Range (0.5f, 3.0f);
			enemyClone.transform.localScale = new Vector3 (scale, scale, scale);
			enemyList.Add (enemyClone);
		}

	}

	Vector3 getRandomV3(){

		return new Vector3 (Random.Range(-25.0f, 25.0f), Random.Range(-25.0f, 25.0f), 0);
	}
}
