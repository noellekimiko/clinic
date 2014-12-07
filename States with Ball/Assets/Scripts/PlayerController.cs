using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public GUIText countText;
	public GUIText gameOverText;
	private int score;
	private int pickupCount;

	public Pickups pickups;

	void Start ()
	{
		score = 0;
		pickupCount = 0;
		SetScoreText();
		gameOverText.text = "";
	}

	void FixedUpdate () {

		Vector3 movement = new Vector3(Input.gyro.gravity.x, 0.0f, Input.gyro.gravity.y);
		Quaternion direction = Quaternion.Euler (0.0f, transform.rotation.y, 0.0f);
		movement = direction * movement;

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
