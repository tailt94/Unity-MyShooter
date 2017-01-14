using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
	public GameObject playButton;
	public GameObject playerShip;
	public GameObject enemySpawner;
	public GameObject GameOverGO;
	public GameObject scoreUITextGO;
	public GameObject TimeCounterGO;
	public GameObject GameTitleGO;

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

			//set game title visible
			GameTitleGO.SetActive(true);
			break;
		case GameManagerState.Playing:
			//Reset score
			scoreUITextGO.GetComponent<GameScore>().Score = 0;

			//hide play button
			playButton.SetActive (false);

			//hide title
			GameTitleGO.SetActive(false);

			//set player visible and init player lives
			playerShip.GetComponent<PlayerControl> ().Init ();

			//start enemy spawner
			enemySpawner.GetComponent<EnemySpawner> ().ScheduleEnemySpawner ();

			//start the time counter
			TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter();
			break;
		case GameManagerState.GameOver:
			//stop time counter
			TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();
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
