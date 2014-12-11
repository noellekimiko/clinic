using UnityEngine;
using System.Collections;

public class LevelGUI : MonoBehaviour {

	private static LevelGUI instance;

	// Creates an instance of LevelGUI as a gameobject if an instance does not exist
	public static LevelGUI Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameObject("LevelGUI").AddComponent<LevelGUI>();
			}
			
			return instance;
		}
	}	
	
	// Sets the instance to null when the application quits
	public void OnApplicationQuit()
	{
		instance = null;
	}

	// Initialize level
	void Start () 
	{
		print ("Loaded: " + GameState.Instance.GetLevel());
	}

	// Provides a GUI on level scenes
	void OnGUI()
	{		
		// Create buttons to move between level 1 and level 2
		if (GUI.Button (new Rect (30, 30, 150, 30), "Load Level 1"))
		{
			print ("Moving to level 1");
			GameState.Instance.SetLevel("Level 1");
			Application.LoadLevel("Scene1");
		}
		
		if (GUI.Button (new Rect (300, 30, 150, 30), "Load Level 2"))
		{
			print ("Moving to level 2");
			GameState.Instance.SetLevel("Level 2");
			Application.LoadLevel("Scene2");
		}

		// Output stats
		GUI.Label(new Rect(30, 100, 400, 30), "Name: " + GameState.Instance.GetName());
		GUI.Label(new Rect(30, 130, 400, 30), "Caffeine Level: " + GameState.Instance.GetCaffeineLevel().ToString());
		GUI.Label(new Rect(30, 160, 400, 30), "Speed: " + GameState.Instance.GetSpeed().ToString());
		GUI.Label(new Rect(30, 190, 400, 30), "Score: " + GameState.Instance.GetScore().ToString());
		GUI.Label(new Rect(30, 220, 400, 30), "Inventory: " + GameState.Instance.GetInventoryString());

	}

	public void SetScoreText ( int incrementAmount ) 
	{
		GameState.Instance.IncreaseScoreByAmount (incrementAmount);
	}

}
