/**********************************************************
***********************************************************
***********************************************************
***														***
***						ID INFORMATION					***
***														***
***	Programmers				  :		  Eddie Meza Jr.	***
***	Assignment #			  :		  Program 4         ***
***	Assignment Name			  :		  GETTING GUI	    ***
*** Course # and Title		  :		  CISC 221			***
*** Class Meeting Time		  :		  TTH 09:35 - 12:45	***
*** Instructor				  :		  Professor Forman	***
*** Hours					  :		  10 				***
*** Difficulty				  :		  5 				***
*** Completion Date			  :		  03/23/2016		***
*** Project Name			  :		  FPS_unity		    ***
***														***
***********************************************************
***********************************************************
***														***
***			Program	Description 						***
***														***
***	  A demo to add a pause menu to the FPS game.	    ***
***   The program has the FPS projects full components. ***
***	  The pause menu can exit the game mode and change  ***
***	  the players and enemy speed.						***
***														***
***********************************************************
***********************************************************
***														***
***					Credits								***
***														***
***		Professor Forman's handout for making it easier ***
***		to compelte the TA.								***
***														***
***														***
***														***
***********************************************************
***********************************************************
***														***					
					Media

***														***
***********************************************************
***********************************************************
**********************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CheckWinLoss : MonoBehaviour {

	private int playerHealth;
	private GameObject player;
	private Control control;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		control = this.gameObject.GetComponent<Control> ();
	}
	
	// Update is called once per frame
	void Update () {

		var playerScript = player.GetComponent<PlayerCharacter> ();

		playerHealth = playerScript.GetPlayerHealth();

		if (this.playerHealth == 0 && Time.timeScale == 1) {
			
			Time.timeScale = 0;

			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;

			GameOverScreen ("Game Over");
		} else 
			if (control.getWinCondition () && Time.timeScale == 1) {
				Time.timeScale = 0;

				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;

				GameOverScreen ("You win. Would you like to play again.");
		}

	
	}

	/**********************************************************
	 * 	NAME: 			GameOverSceen 
	 *  DESCRIPTION:	Creates a UI interface to tell the 
	 * 					player that he won or lost and asked
	 * 					them if they want to play again.
	 * 
	 * ********************************************************/
	private void GameOverScreen(string message){

		UIMakerScript menuMaker = new UIMakerScript ();

		GameObject canvas = menuMaker.CreateCanvas(this.transform);

		menuMaker.CreateEventSystem(canvas.transform);

		GameObject panel = menuMaker.CreatePanel(canvas.transform);

		menuMaker.CreateText(panel.transform, new Vector2(-20, 50), new Vector2(160, 50), "headerText",message, 14);

		menuMaker.CreateButton(panel.transform, new Vector2(0, -30), new Vector2(75, 25), "ExitButton","No", delegate{Exit();});
		menuMaker.CreateButton(panel.transform, new Vector2(0, 05), new Vector2(75, 25), "RestartButton","Yes", delegate{ResetScene();});

    }

	/**********************************************************
	 * 	NAME: 			ResetScene
	 *  DESCRIPTION:	Uses the ScenceManger.LoadScene to retart
	 * 					the game.
	 * 
	 * ********************************************************/
    private void ResetScene() {
        SceneManager.LoadScene("Maze");
    }

	/**********************************************************
	 * 	NAME: 			Exit
	 *  DESCRIPTION:	Exits the play mode in the editor by
	 * 					setting the isPlaying in the
	 * 					EditorApplication to false. 
	 * 
	 * ********************************************************/
	private void Exit(){

		UnityEditor.EditorApplication.isPlaying = false;

	}
}
