using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject EnemyGO;
	float maxSpawnRateInSeconds = 4f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnEnemy() {
		//Bottom-left point of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//Top-right point of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		//Imstantiate enemy;
		GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
		anEnemy.transform.position = new Vector2 (Random.Range(min.x, max.x), max.y);

		//Schedule when to spawn next enemy
		ScheduleNextEnemySpawn();
	}

	void ScheduleNextEnemySpawn() {
		float spawnInNSeconds;
		if (maxSpawnRateInSeconds > 1f) {
			spawnInNSeconds = Random.Range (1f, maxSpawnRateInSeconds);
		} else {
			spawnInNSeconds = 1f;
		}
		Invoke ("SpawnEnemy", spawnInNSeconds);
	}

	void IncreaseSpawnRate() {
		if (maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--;

		if (maxSpawnRateInSeconds == 1f)
			CancelInvoke ("IncreaseSpawnRate");
	}

	public void ScheduleEnemySpawner() {
		//reset max soawn rate
		maxSpawnRateInSeconds = 5f;

		Invoke ("SpawnEnemy", maxSpawnRateInSeconds);

		//Increase spawn rate every 30 seconds;
		InvokeRepeating("IncreaseSpawnRate", 0f, 20f);
	}

	public void UnscheduleEnemySpawner() {
		CancelInvoke ("SpawnEnemy");
		CancelInvoke ("IncreaseSpawnRate");
	}
}
