using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class CharController : MonoBehaviour {
	CharacterController characterController;
	float mouseSensitivity = 5.0f;
	GameObject[] envObjects;

	public GameObject coffee;
	public GUIText caffeineLabel;
	public GUIText speedLabel;
	float timer = 2.0f;
	public int caffeine = 10;
	float movementSpeed = 5.0f;

	float verticalVelocity = 0;
	float verticalRotation = 0;
	public float updownRange = 60.0f;
	float jumpSpeed = 7;
	
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController> ();
		//envObjects = GameObject.FindGameObjectsWithTag("env");
	}
	
	// Update is called once per frame
	void Update () {
		updateCaffeine ();

		// Rotation to view scene
		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotLeftRight, 0);
		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -updownRange, updownRange);
		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);
		
		// Spacebar control
		if (Input.GetButtonDown ("Jump")) {
			//verticalVelocity = jumpSpeed; // code to jump
		}

		// Movement control using directional keys
		float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;
				
		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed);
		speed = transform.rotation * speed;
		characterController.Move (speed * Time.deltaTime);
	}

	// Update player caffeine level and movement speed
	void updateCaffeine() {
		if (caffeine <= 0) {
			caffeine = 0;
			movementSpeed = 0; // game over screen
		} else {
			movementSpeed = (float) (caffeine * 0.5);
		}

		caffeineLabel.text = "Caffeine Level: " + caffeine;
		speedLabel.text = "Current Speed: " + movementSpeed;

		if (timer > 0) {
			timer -= Time.deltaTime;
		} else {
			timer = 2.0f;
			caffeine -= 1;
		}
	}


}
