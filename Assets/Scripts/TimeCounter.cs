using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {
	Text timeUI;
	float startTime; //the time when user click Play button
	float ellapsedTime; // the ellapsed time after user click play button
	bool startCounter; //flag to start counter

	int minutes;
	int seconds;

	// Use this for initialization
	void Start () {
		startCounter = false;

		//get the text UI component from this  gameObject
		timeUI = GetComponent<Text>();
	}

	public void StartTimeCounter() {
		startTime = Time.time;
		startCounter = true;
	}

	public void StopTimeCounter() {
		startCounter = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (startCounter) {
			//calculate ellapsed time
			ellapsedTime = Time.time - startTime;

			minutes = (int)ellapsedTime / 60;
			seconds = (int)ellapsedTime % 60;

			//update time counter ui text
			timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
		}
	}
}
