using UnityEngine;
using System.Collections;

public class KeyPressPlayerController : MonoBehaviour {

	public float speed;
	public GUIText countText;
	public GUIText gameOverText;
	private int score;
	private int pickupCount;

	// In the inspector, set this to the gameobject that has the pickup script associated with it
	public Pickups pickups; 

	void Start ()
	{
		score = 0;
		pickupCount = 0;
		SetScoreText();
		gameOverText.text = "";
	}
	
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
			score += 1;
			pickupCount += 1;
			SetScoreText();
		}

		if (other.gameObject.tag == "Avoid") 
		{
			other.gameObject.SetActive(false);
			score -= 1;
			SetScoreText();
		}
	}
	
	void SetScoreText () 
	{
		countText.text = "Score: " + score.ToString();
		SetGameOverText();
	}
	
	void SetGameOverText () {
		if (pickupCount >= pickups.numPickups) 
		{
			gameOverText.text = "Game Over!";
		}
	}
}
