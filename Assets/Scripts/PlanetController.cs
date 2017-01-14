using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {
	public GameObject[] Planets;

	//Queue to hold planets
	Queue<GameObject> availablePlanets = new Queue<GameObject>();
	// Use this for initialization
	void Start () {
		//add planets to Queue
		availablePlanets.Enqueue(Planets[0]);
		availablePlanets.Enqueue(Planets[1]);
		availablePlanets.Enqueue(Planets[2]);

		//call MovePlaneDown every 20s
		InvokeRepeating("MovePlanetDown", 0, 20f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Function to dequeue a planet, and set isMoving flag to true
	//so that the planet starts scrolling down
	void MovePlanetDown() {
		//return if the queue is empty
		if (availablePlanets.Count == 0) {
			return;
		}

		//get a planet from the queue
		GameObject aPlanet = availablePlanets.Dequeue();

		//set the planet isMoving flag to true
		aPlanet.GetComponent<Planet>().isMoving = true;
	}

	//Enqueue planets that are below screen and are not moving
	void EnqueuPlanets() {
		foreach (GameObject aPlanet in Planets) {
			//if the planet if below the screen, and the planet is not moving
			if ((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<Planet> ().isMoving)) {
				//reset planet position
				aPlanet.GetComponent<Planet>().ResetPosition();

				//Enqueue planet	
				availablePlanets.Enqueue(aPlanet);
			}
		}
	}
}
