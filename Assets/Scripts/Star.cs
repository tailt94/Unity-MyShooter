using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//get current position
		Vector2 position = transform.position;

		//calculate new position
		position = new Vector2(position.x, position.y + speed * Time.deltaTime);

		//Update star position
		transform.position = position;

		//bottom-left point of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//top-right point of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		//If star outside of screen on the bottom,
		//position star on the top edge of screen
		// and randomly between the left and right side of the screen
		if (transform.position.y < min.y) {
			transform.position = new Vector2 (Random.Range(min.x, max.x), max.y);
		}

	}
}
