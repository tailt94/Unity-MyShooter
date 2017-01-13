using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {
	public GameObject EnemyBulletGO;
	// Use this for initialization
	void Start () {
		Invoke ("FireBullet", 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FireBullet() {
		GameObject playerShip = GameObject.Find ("PlayerGO");

		if (playerShip != null) {
			GameObject bullet = (GameObject)Instantiate (EnemyBulletGO);

			//set bullet initial position
			bullet.transform.position = transform.position;

			//calculate direction toward player ship
			Vector2 direction = playerShip.transform.position - bullet.transform.position;

			//set bullet position
			bullet.GetComponent<EnemyBullet>().SetDirection(direction);
		}
	}
}
