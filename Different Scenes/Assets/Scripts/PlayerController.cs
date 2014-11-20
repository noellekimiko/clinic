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
		GUI.Box(new Rect(20,20,300,200), "Scenes");

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(25,45,290,80), "Birch")) 
		{
			Application.LoadLevel(0);
		}
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(25,130,290,80), "Libra Complex")) 
		{
			Application.LoadLevel(1);
		}
	}
}
