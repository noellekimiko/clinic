using UnityEngine;
using System.Collections;

public class Pickups : MonoBehaviour {
	
	public GameObject pickupPrefab;
	public int numPickups;
	public GameObject avoidPrefab;
	public int numAvoids;
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;

	private Vector3[] occupiedLocations;
	private float sphereRadius = 0.5F;

	//	If you could program a list of acceptable locations ahead of time and then randomly choose one
	//	public Transform[] locationsArray;
	
	void Start () {

		occupiedLocations = new Vector3[numPickups + numAvoids];

		// Place coins -- these give you 1 point
		for (int i = 0; i < numPickups; i++) {
			Vector3 location = getRandomLocation();

			// Make sure that location is empty
			while(!isEmpty(location)) {
				location = getRandomLocation();
			}

			Instantiate(pickupPrefab, location, Quaternion.identity);
			occupiedLocations[i] = location;
		}

		// Place cubes -- these subtract from the score
		for (int k = 0; k < numAvoids; k++) {
			Vector3 location = getRandomLocation();
			
			// Make sure that location is empty
			while(!isEmpty(location)) {
				location = getRandomLocation();
			}
			
			Instantiate(avoidPrefab, location, Quaternion.identity);
			occupiedLocations[numPickups + k] = location;
		}
	}

	private Vector3 getRandomLocation() {
		// Y should always be 0.5F so pickups are slightly above the board
		float Y_COORDINATE = 0.5F;

		// x and z generated randomly
		float x = Random.Range(xMin, xMax);
		float z = Random.Range(zMin, zMax);

		Vector3 location = new Vector3 (x, Y_COORDINATE, z);

		return location;
	}

	private bool isEmpty(Vector3 location) {
		for (int j = 0; j < numPickups; j++) {
			if (Physics.CheckSphere(location, sphereRadius)) {
				return false;
			}
		}
		return true;
	}

//	// Update is called once per frame
//	void Update () {
//	
//	}
}