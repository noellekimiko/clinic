using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class CharController : MonoBehaviour {
	CharacterController characterController;
	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 5.0f;
	GameObject[] envObjects;
	
	float verticalVelocity = 0;
	float verticalRotation = 0;
	public float updownRange = 60.0f;
	float jumpSpeed = 7;
	
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController> ();
		envObjects = GameObject.FindGameObjectsWithTag("env");
	}
	
	// Update is called once per frame
	void Update () {
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
}
