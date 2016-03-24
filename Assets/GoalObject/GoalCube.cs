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

public class GoalCube : MonoBehaviour {

	private PauseMenu isPause;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.timeScale == 1)
			this.transform.Rotate (0, 0, 5);
	}

	/**********************************************************
	 * 	NAME: 			OnTriggerEnter
	 *  DESCRIPTION:	Checks to whether the player and the 
	 * 					GoalCube have collided. If so then destory
	 * 					the GoalCube.
	 * 
	 * ********************************************************/
	void OnTriggerEnter(Collider other){
		var player = other.GetComponent<PlayerCharacter> ();
		if(player != null)
			Destroy (this.gameObject);
	} 
}
