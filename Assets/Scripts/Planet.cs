using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
	public float speed;
	public bool isMoving; //flag to make planet scroll down

	Vector2 min;
	Vector2 max;

	void Awake() {
		isMoving = false;
		min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		//add planet sprite half height to max y
		max.y = max.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y;

		//subtract the planet sprite half height to min y
		min.y = min.y - GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isMoving) {
			return;
		}

		//get current position of planet
		Vector2 position = transform.position;

		//Calculate new position
		position = new Vector2(position.x, position.y + speed * Time.deltaTime);

		//Update planet position;
		transform.position = position;

		//If planet gets to min y position, top moving planet
		if (transform.position.y < min.y) {
			isMoving = false;
		}
	}

	public void ResetPosition() {
		//reset position of planet to random x, max y
		transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
	}
}
