using UnityEngine;
using System.Collections;

public class LevelGUI : MonoBehaviour {

	// Initialize level
	void Start () 
	{
		print ("Loaded: " + GameState.Instance.getLevel());
	}

	// Provides a GUI on level scenes
	void OnGUI()
	{		
		// Create buttons to move between level 1 and level 2
		if (GUI.Button (new Rect (30, 30, 150, 30), "Load Level 1"))
		{
			print ("Moving to level 1");
			GameState.Instance.setLevel("Level 1");
			Application.LoadLevel("scene1");
		}
		
		if (GUI.Button (new Rect (300, 30, 150, 30), "Load Level 2"))
		{
			print ("Moving to level 2");
			GameState.Instance.setLevel("Level 2");
			Application.LoadLevel("scene2");
		}

		// Output stats
		GUI.Label(new Rect(30, 100, 400, 30), "Name: " + GameState.Instance.getName());
		GUI.Label(new Rect(30, 130, 400, 30), "HP: " + GameState.Instance.getHP().ToString());
		GUI.Label(new Rect(30, 160, 400, 30), "MP: " + GameState.Instance.getMP().ToString());
	}
}
