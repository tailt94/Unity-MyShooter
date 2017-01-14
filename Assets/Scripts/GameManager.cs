using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
	public GameObject playButton;
	public GameObject playerShip;
	public GameObject enemySpawner;
	public GameObject GameOverGO;

	public enum GameManagerState {
		Opening,
		Playing,
		GameOver,
	}

	GameManagerState GMState;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void UpdateGameManagerState() {
		switch (GMState) {
		case GameManagerState.Opening:
			//Hide game over
			GameOverGO.SetActive(false);
			//Set play button active
			playButton.SetActive(true);
			break;
		case GameManagerState.Playing:
			playButton.SetActive (false);
			playerShip.GetComponent<PlayerControl> ().Init ();
			enemySpawner.GetComponent<EnemySpawner> ().ScheduleEnemySpawner ();
			break;
		case GameManagerState.GameOver:
			//Stop enemy spawner
			enemySpawner.GetComponent<EnemySpawner> ().UnscheduleEnemySpawner ();
			//Display GameOver UI	
			GameOverGO.SetActive(true);
			//Change game manager state to opening
			Invoke("ChangeToOpeningState", 5f);
			break;
		}
	}

	public void SetGameManagerState(GameManagerState state) {
		GMState = state;
		UpdateGameManagerState ();
	}

	//Call this method when click Play button
	public void StartGamePlay() {
		GMState = GameManagerState.Playing;
		UpdateGameManagerState ();
	}

	public void ChangeToOpeningState() {
		SetGameManagerState (GameManagerState.Opening);
	}
}
