using UnityEngine;
using System.Collections;

public class CoffeeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.enabled = false;
		collider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameState.Instance.GetCaffeineLevel() < 8) {
			renderer.enabled = true;
			collider.enabled = true;
		} else {
			renderer.enabled = false;
			collider.enabled = false;
		}
	}

	void OnTriggerEnter (Collider other) {
		GameState.Instance.SetCaffeineLevel(10);
		GameState.Instance.UpdateCaffeine ();
	}
}
