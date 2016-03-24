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

public class UIController : MonoBehaviour
{
	private Control score;

	private GameEvent gameEvent = new GameEvent();

	void Start(){
		score = this.gameObject.GetComponent<Control> ();
	}

	/**********************************************************
	 * 	NAME: 			Awake
	 *  DESCRIPTION:	Adds the Listner to the messenger for 
	 * 					the broadcasting event.
	 * 
	 * ********************************************************/
	void Awake(){
		Messenger.AddListener (gameEvent.HitMessage, OnEnemyHit);
	}

	/**********************************************************
	 * 	NAME: 			OnDestory
	 *  DESCRIPTION:	when the UIController is destroyed 
	 * 					Remove the Listner to avoid errors
	 * 
	 * ********************************************************/
	void OnDestory(){
		Messenger.RemoveListener (gameEvent.HitMessage, OnEnemyHit);
	}

	/**********************************************************
	 * 	NAME: 			OnEnemyHit
	 *  DESCRIPTION:	increment the score by one.
	 * 
	 * ********************************************************/
	private void OnEnemyHit(){

		score.Score += 1;
	}
}

