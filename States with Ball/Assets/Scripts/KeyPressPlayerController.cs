using UnityEngine;
using System.Collections;

public class KeyPressPlayerController : MonoBehaviour {

	public float speed;

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rigidbody.AddForce(movement * speed * Time.deltaTime); //omitting second argument
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
