using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	private static GameState instance;
	private string activeLevel;			// Active level
	private string name;				// Characters name
	private int maxHP;					// Max HP
	private int maxMP;					// Map MP
	private int hp;						// Current HP
	private int mp;						// Current MP
	private int strength;					// Characters Strength
	private int vitality;					// Characters Vitality
	private int dexterity;					// Characters Dexterity
	private int experience;					// Characters Experience Points

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
		maxHP = 250;
		maxMP = 60;
		hp = maxHP;
		mp = maxMP;
		strength = 6;
		vitality = 5;
		dexterity = 7;
		experience = 0;

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

	// Returns the characters hp
	public int getHP()
	{
		return hp;
	}
	
	// Returns the characters mp
	public int getMP()
	{
		return mp;
	}
}
