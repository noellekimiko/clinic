using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	void OnGUI () 
	{
		if(GUI.Button(new Rect (30, 30, 150, 30), "Start Game"))
		{
			startGame();
		}
	}

	
	private void startGame()
	{
		print("Starting game");
		
		DontDestroyOnLoad(GameState.Instance);
		GameState.Instance.startState();
	}
}
