using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Script : MonoBehaviour {



	public float spawnRate;
	public float startDelay;
	public GameObject enemyPrefab;
	GameObject enemyClone;
	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("spawnEnemy", startDelay, spawnRate);


	}
	
	// Update is called once per frame
	void Update () {




	}
	void spawnEnemy(){

		enemyClone = Instantiate (enemyPrefab, getRandomV3(), Quaternion.identity) as GameObject;
		float scale = Random.Range (0.5f, 3.0f);
		enemyClone.transform.localScale = new Vector3 (scale, scale, scale);

	}

	Vector3 getRandomV3(){

		return new Vector3 (Random.Range(-25.0f, 25.0f), Random.Range(-25.0f, 25.0f), 0);
	}
}
