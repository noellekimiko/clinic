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
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce(movement * speed * Time.deltaTime); //omitting second argument

	}
	
	void OnTriggerEnter(Collider other) 
	{
		// Destroy(other.gameObject);
		
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
