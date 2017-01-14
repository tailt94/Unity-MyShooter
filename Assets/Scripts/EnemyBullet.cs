using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
	float speed;
	Vector2 _direction; //bullet direction
	bool isReady; //to know when the bullet direction is set

	void Awake() {
		speed = 5f;
		isReady = false;
	}
	// Use this for initialization
	void Start () {
		
	}

	public void SetDirection(Vector2 direction) {
		_direction = direction.normalized;
		isReady = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isReady) {
			//get bullet current position
			Vector2 position = transform.position;

			//calculate new position
			position += _direction * speed * Time.deltaTime;

			//update position
			transform.position = position;

			//Destroy bullet if it's outside of the screen


			//Bottom-left point of the screen
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

			//Top-right
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

			//Destroy
			if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
			   (transform.position.y < min.y) || (transform.position.y > max.y)) {
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		//Collisiton between player ship - enemy ship or bullet
		if (col.tag == "PlayerShipTag") {
			Destroy (gameObject);
		}
	}
}
