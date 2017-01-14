﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public GameObject PlayerBulletGO;
	public GameObject bulletPosition01;
	public GameObject bulletPosition02;
	public GameObject ExplosionGO;
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//fire bullet if the spacebar is pressed
		if(Input.GetKeyDown("space")) {
			//FIrst bullet
			GameObject bullet01 = (GameObject) Instantiate(PlayerBulletGO);
			bullet01.transform.position = bulletPosition01.transform.position; //set initial position	

			//Second bullet
			GameObject bullet02 = (GameObject) Instantiate(PlayerBulletGO);
			bullet02.transform.position = bulletPosition02.transform.position; //set initial position	
		}

		//Return -1, 0 or 1 (left, no input, right)
		float x = Input.GetAxisRaw ("Horizontal");
		//Return -1, 0 or 1 (down, no input, rup)
		float y = Input.GetAxisRaw ("Vertical");

		//get a direction and normalize to unit vector
		Vector2 direction = new Vector2 (x, y).normalized;

		Move (direction); 
	}

	void Move(Vector2 direction) {
		//Limit to  player movement (left, right, top, bottom edge of screen)
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0)); //bottom-left point of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1)); //top-right point of screen

		max.x = max.x - 0.225f; //subtract half width of player sprite
		min.x = min.x + 0.225f; //add half width of player sprite

		max.y = max.y - 0.285f; //subtract half height of player sprite
		min.y = min.y + 0.285f; //add half height of player sprite

		//Get current position of player
		Vector2 currPos = transform.position;

		//Calculate new position
		currPos += direction * speed * Time.deltaTime;

		//Makesure new position is not outside the screen
		currPos.x = Mathf.Clamp(currPos.x, min.x, max.x);
		currPos.y = Mathf.Clamp(currPos.y, min.y, max.y);

		//Update player position
		transform.position = currPos;
	}

	void OnTriggerEnter2D(Collider2D col) {
		//Collisiton between player ship - enemy ship or bullet
		if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag")) {
			PlayExplosion ();
			Destroy (gameObject);
		}
	}

	void PlayExplosion() {
		GameObject explosion = (GameObject)Instantiate (ExplosionGO);
		explosion.transform.position = transform.position;
	}
}
