using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	private static GameState instance;
	private string activeLevel;			// Active level
	private string name;				// Character's name
	private int maxCaffeineLevel;		// Max caffeine level
	private int caffeineLevel;			// Current caffeine level
	private int strength;				// Character's Strength
	private int vitality;				// Character's Vitality
	private int experience;				// Character's Experience Points
	private int speed;					// Character's Speed
	private string[] inventory;			// Items a character has
	private int numInventoryItems;

	// Creates an instance of GameState as a gameobject if an instance does not exist
	public static GameState Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameObject("GameState").AddComponent<GameState>();
			}
			
			return instance;
		}
	}	
	
	// Sets the instance to null when the application quits
	public void OnApplicationQuit()
	{
		instance = null;
	}
	
	// Creates a new game state
	public void startState()
	{
		print ("Creating a new game state");

		// Set default properties:
		activeLevel = "Level 1";
		name = "My Character";
		maxCaffeineLevel = 250;
		caffeineLevel = maxCaffeineLevel;
		strength = 6;
		vitality = 5;
		experience = 0;
		speed = (caffeineLevel / 10);
		numInventoryItems = 8;
		inventory = new string[numInventoryItems];
		inventory[0] = "hi";

		// Load level 1
		Application.LoadLevel("scene1");
	}

	// Returns the currently active level
	public string getLevel()
	{
		return activeLevel;
	}
	
	// Sets the currently active level to a new value
	public void setLevel(string newLevel)
	{
		activeLevel = newLevel;
	}

	// Returns the characters name
	public string getName()
	{
		return name;
	}

	// Returns the character's caffeine level
	public int getCaffeineLevel()
	{
		return caffeineLevel;
	}

	public int getSpeed()
	{
		return speed;
	}

	public string getInventoryString() 
	{
		string returnVal = "";
		for(int i = 0; i < inventory.Length; i++)
		{
			returnVal += inventory[i];
		}

		return returnVal;
	}
}
