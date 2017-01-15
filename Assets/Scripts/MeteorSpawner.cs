using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

	public GameObject MeteorGO;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnMeteor() {
		//Bottom-left point of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//Top-right point of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		GameObject aMeteor = (GameObject)Instantiate (MeteorGO);
		aMeteor.transform.position = new Vector2 (Random.Range(min.x, max.x), max.y);

		ScheduleMeteorSpawner ();
	}

	public void ScheduleMeteorSpawner() {
		Invoke ("SpawnMeteor", 5f);
	}

	public void UnscheduleMeteorSpawner() {
		CancelInvoke ("SpawnMeteor");
	}
}
