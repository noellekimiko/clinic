using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;
	private int NUM_OBJECTS;

	void Start ()
	{
		count = 0;
		SetCountText();
		winText.text = "";
		NUM_OBJECTS = 3;
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
			count += 1;
			SetCountText();
		}
	}

	void SetCountText () 
	{
		countText.text = "Count: " + count.ToString();
		if (count >= NUM_OBJECTS) 
		{
			winText.text = "You Win!";
		}
	}
}
