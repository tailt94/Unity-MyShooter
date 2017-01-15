using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorControl : MonoBehaviour {
	GameObject MeteorGO;
	float moveSpeed;
	float rotateSpeed;
	// Use this for initialization
	void Start () {
		moveSpeed = 1.2f;
		rotateSpeed = Random.Range (-1.2f, 1.2f);
	}

	// Update is called once per frame
	void Update () {
		//rotate meteor
		transform.RotateAround(transform.position, new Vector3(0, 0, 1), rotateSpeed);

		//get current position
		Vector2 position = transform.position;

		//calculate new position
		position = new Vector2 (position.x, position.y - moveSpeed * Time.deltaTime);

		//update new position
		transform.position = position;

		//Bottm-left point of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//Destroy enemy object if it's outside of the screen
		if (transform.position.y < min.y) {
			Destroy (gameObject);
		}
		
	}
}
