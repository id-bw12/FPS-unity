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
using System.Collections;

public class Control : MonoBehaviour {

	private Renderer[] render;

	private GameObject enemy, endingCube;

	private int enemyKilled = 0, score = 0;

	private bool playerWins = false, goalObject = false;


	// Use this for initialization
	void Start () {

        Time.timeScale = 1;

		//makeEnemy ();

		MakeGreaterEnemy ();

		enemy = MakeGreaterEnemy ();

		enemy.GetComponent<Level2Enemy> ().Health = 4;

		enemy.GetComponent<Level2Enemy> ().ChangeSize();

		GameObject floor = GameObject.Find ("Floor");

		render = floor.GetComponentsInChildren<Renderer> ();

		for (int i = 0; i < render.Length; ++i) 
			render [i].material.color = Color.blue;

        GameObject gameLight = GameObject.Find("Directional Light");

        gameLight.transform.Rotate(50, 330, 0);

	}
	
	// Update is called once per frame
	void Update () {

		if (enemy == null && enemyKilled < 4) {
			//makeEnemy ();

			MakeGreaterEnemy ();
			++enemyKilled;

		} else if (enemyKilled == 4 && !goalObject) {
			endingCube = MakeGoalObject ();
            print("hey");
			goalObject = true;
		}
		else
			if (endingCube == null && goalObject)
				playerWins = true;
			
			
	}

	/**********************************************************
	 * 	NAME: 			MakeGoalObject
	 *  DESCRIPTION:	Makes the goal cube and returns it.
	 * 
	 * ********************************************************/
	private GameObject MakeGoalObject(){
	
		var cube = GameObject.CreatePrimitive (PrimitiveType.Cube);

		cube.GetComponent<BoxCollider> ().isTrigger = true;

		cube.AddComponent<Rigidbody> ();

		cube.AddComponent<MeshRenderer> ().material.color = Color.green;

		cube.AddComponent<GoalCube> ();

		cube.transform.Rotate(50,0,0);

		cube.transform.localPosition = new Vector3 (0, 1, 0);

		return cube;
	}

	/**********************************************************
	 * 	NAME: 			makeEnemy
	 *  DESCRIPTION:	Makes a basic enemy for the player to 
	 * 					face.
	 * 
	 * ********************************************************/
	private void makeEnemy(){

		float angle = Random.Range (0, 360);

		enemy = GameObject.CreatePrimitive (PrimitiveType.Cube);

		enemy.transform.localScale += new Vector3 (0.0f,2.0f,0.0f);

		enemy.transform.localPosition = new Vector3 (0,1,0);

		enemy.transform.Rotate(0, angle, 0);

		enemy.GetComponent<MeshRenderer> ().material.color = Color.black;

		enemy.AddComponent<ReactiveTarget>();

		enemy.AddComponent<AIMovement> ();
	}

	/**********************************************************
	 * 	NAME: 			MakeGreaterEnemy
	 *  DESCRIPTION:	Makes a stronger enemy for the player to 
	 * 					face and returns it.
	 * 
	 * ********************************************************/
	private GameObject MakeGreaterEnemy(){

		float angle = Random.Range (0, 360);

		enemy = GameObject.CreatePrimitive (PrimitiveType.Cube);

		enemy.name = "Enemy 2";

		enemy.transform.Rotate(0, angle, 0);

		enemy.GetComponent<MeshRenderer> ();

		enemy.AddComponent<ReactiveTarget>();

		enemy.AddComponent<Level2Enemy> ();

		var stats = enemy.GetComponent<Level2Enemy> ();

		stats.EnemyColor = Color.gray;

		stats.Health = 5;

		stats.SetColor ();

		stats.SetAIPathing ();

		return enemy;
		
	}

	/**********************************************************
	 * 	NAME: 			getWinCondition
	 *  DESCRIPTION:	returns the playerWins boolean to see if
	 * 					the player has won.
	 * 
	 * ********************************************************/
	public bool getWinCondition(){

		return playerWins;
	}

	/**********************************************************
	 * 	NAME: 			Score 
	 *  DESCRIPTION:	gets or sets the the current score
	 * 
	 * ********************************************************/
	public int Score{
		get{ return score; }
		set{ score = value;}
	}
}
