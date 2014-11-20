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
	
	void OnGUI () 
	{
		GUI.Box(new Rect(20,20,300,80), "");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,20,300,80), "Restart Level")) 
		{
			Application.LoadLevel(0);
		}
	}
}
