﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour {
	public GameObject StarGO;
	public int MaxStars; //maximum number of star

	//Array of colors
	Color[] starColors = {
		new Color(0.5f, 0.5f, 1f), //blue
		new Color(0, 1f, 1f), //green
		new Color(1f, 1f, 0), //yellow
		new Color(1f, 0f, 0f), //red
	};

	// Use this for initialization
	void Start () {

		//bottom-left point of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		//Loop to create stars
		for (int i = 0; i < MaxStars; i++) {
			GameObject star = (GameObject)Instantiate (StarGO);

			//set star color
			star.GetComponent<SpriteRenderer>().color = starColors[i% starColors.Length];

			//set position of star
			star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

			//set random speed
			star.GetComponent<Star>().speed = -(1f * Random.value + 0.5f);

			//make the star a child of StarGeneratorGO
			star.transform.parent = transform;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
