using UnityEngine;
using System.Collections;

public class KeyPressPlayerController : MonoBehaviour {

	public int caffeineStartingLevel;

	void Start () {
		GameState.Instance.SetCaffeineLevel (caffeineStartingLevel);
	}

	void FixedUpdate () {
		// Movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce(movement * (GameState.Instance.GetSpeed() * 100) * Time.deltaTime);

		GameState.Instance.UpdateCaffeine ();
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "PickUp") 
		{
			other.gameObject.SetActive(false);
			GameState.Instance.AddToInventory(other.gameObject.tag);
			LevelGUI.Instance.SetScoreText(+1);
		}
		
		if (other.gameObject.tag == "Avoid") 
		{
			other.gameObject.SetActive(false);
			GameState.Instance.AddToInventory(other.gameObject.tag);
			LevelGUI.Instance.SetScoreText(-1);
		}

		if (other.gameObject.tag == "Special") 
		{
			if (GameState.Instance.CheckInventory("PickUp", 3)) 
			{
				other.gameObject.SetActive(false);
				GameState.Instance.AddToInventory(other.gameObject.tag);
				LevelGUI.Instance.SetScoreText(+5);
			}
		}
	}
}
