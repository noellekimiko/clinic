using UnityEngine;
using System.Collections;
using System;

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
	private ArrayList inventory;			// Items a character has
	private int numInventoryItems;

	private int score;
	private int pickupCount;
	
	// In the inspector, set this to the gameobject that has the pickup script associated with it
	public Pickups pickups; 

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
		inventory = new ArrayList();
		score = 0;
		pickupCount = 0;

		// Load level 1
		Application.LoadLevel(1);
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
		string returnString = "";
		for(int i = 0; i < inventory.Count; i++)
		{
			returnString += inventory[i];
			returnString += " ";
		}
		
		return returnString;
	}

	public int getScore()
	{
		return score;
	}

	public int getPickupCount()
	{
		return pickupCount;
	}

	public void setScore(int incrementAmount)
	{
		score += incrementAmount;
	}

	public void AddToInventory(string item) 
	{
		inventory.Add(item);
	}

	public bool CheckInventory(string item, int numItems)
	{
		int numInInventory = 0;
		for(int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].Equals(item)) {
				numInInventory += 1;
			}
		}

		return (numItems <= numInInventory);
	}
	
}
