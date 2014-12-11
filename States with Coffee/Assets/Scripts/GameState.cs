using UnityEngine;
using System.Collections;
using System;

public class GameState : MonoBehaviour {

	private static GameState instance;

	private string activeLevel;			// Active level
	private int caffeineLevel;			// Current caffeine level
	private ArrayList inventory;		// Items a character has
	private string name;				// Character's name
	private int numInventoryItems;		// Possible number of items a character can have
	private int numLives;				// Character's Vitality
	private int numLivesPossible;		// Possible number of lives
	private int pickupCount;
	private int score;
	private float speed;				// Character's Speed
	private float timer;
	
	// In the inspector, set this to the gameobject that has the pickup script associated with it
//	public Pickups pickups;  

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
		caffeineLevel = 20;
		inventory = new ArrayList();
		name = "My Character";
		numInventoryItems = 8;
		numLives = 5;
		numLivesPossible = 5;
		pickupCount = 0;
		score = 0;
		speed = 5.0f;
		timer = 2.0f;

		// Load level 1
		Application.LoadLevel(1);
	}

	// activeLevel
	public string GetLevel()
	{
		return activeLevel;
	}

	public void SetLevel( string newLevel )
	{
		activeLevel = newLevel;
	}

	// caffeineLevel
	public int GetCaffeineLevel()
	{
		return caffeineLevel;
	}

	public void SetCaffeineLevel( int newCaffeineLevel )
	{
		caffeineLevel = newCaffeineLevel;
	}

	public void UpdateCaffeine() {
		if (caffeineLevel <= 0) {
			caffeineLevel = 0;
			speed = 0; // game over screen
		} else {
			speed = (float) (caffeineLevel * 0.5);
		}
		
		if (timer > 0) {
			timer -= Time.deltaTime;
		} else {
			timer = 2.0f;
			caffeineLevel -= 1;
		}
	}


	// inventory
	public ArrayList GetInventory()
	{
		return inventory;
	}
	
	public void SetInventory( ArrayList newInventory )
	{
		inventory = newInventory;
	}

	public string GetInventoryString() 
	{
		string returnString = "";
		for(int i = 0; i < inventory.Count; i++)
		{
			returnString += inventory[i];
			returnString += " ";
		}
		
		return returnString;
	}

	public void AddToInventory( string item ) 
	{
		inventory.Add(item);
	}
	
	public bool CheckInventory( string item, int numItems )
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

	// name
	public string GetName()
	{
		return name;
	}

	public void SetName( string newName )
	{
		name = newName;
	}

	// numInventoryItems
	public int GetNumInventoryItems()
	{
		return numInventoryItems;
	}
	
	public void SetNumInventoryItems( int newNumInventoryItems )
	{
		numInventoryItems = newNumInventoryItems;
	}

	// numLives
	public int GetNumLives()
	{
		return numLives;
	}
	
	public void SetNumLives( int newNumLives )
	{
		numLives = newNumLives;
	}

	// numLivesPossible
	public int GetNumLivesPossible()
	{
		return numLivesPossible;
	}
	
	public void SetNumLivesPossible( int newNumLivesPossible )
	{
		numLivesPossible = newNumLivesPossible;
	}

	// pickupCount
	public int GetPickupCount()
	{
		return pickupCount;
	}
	
	public void SetPickupCount( int newPickupCount )
	{
		pickupCount = newPickupCount;
	}

	public void IncrementPickupCount ()
	{
		pickupCount += 1;
	}

	// score	
	public int GetScore()
	{
		return score;
	}
	
	public void IncreaseScoreByAmount (int incrementAmount)
	{
		score += incrementAmount;
	}
	
	public void IncrementScore ()
	{
		score += 1;
	}

	// speed
	public float GetSpeed()
	{
		return speed;
	}

	public void SetSpeed( float newSpeed)
	{
		speed = newSpeed;
	}

	// timer
	public float GetTimer()
	{
		return timer;
	}
	
	public void SetTimer( float newTimer)
	{
		timer = newTimer;
	}
	
}
