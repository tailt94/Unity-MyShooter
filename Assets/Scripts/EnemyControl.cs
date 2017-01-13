﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
	float speed;
	// Use this for initialization
	void Start () {
		speed = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		//Get enemy current position
		Vector2 position = transform.position;

		//Calculate new position
		position = new Vector2(position.x, position.y - speed *  Time.deltaTime);

		//Update enemy position
		transform.position = position;

		//Bottm-left point of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//Destroy enemy object if it's outside of the screen
		if (transform.position.y < min.y) {
			Destroy (gameObject);
		}
	}
}