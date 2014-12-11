using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;

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
