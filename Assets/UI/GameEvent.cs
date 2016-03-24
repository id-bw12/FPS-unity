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

public class GameEvent : MonoBehaviour {

	private const string ENEMY_HIT = "ENEMY_HIT";
	private const string SPEED_CHANGED = "SPEED_CHANGED";

	/**********************************************************
	 * 	NAME: 			SpeedMessage
	 *  DESCRIPTION:	gets the SPEED_CHANGED string
	 * 
	 * ********************************************************/
	public string SpeedMessage{
		get{ return SPEED_CHANGED;}
	}

	/**********************************************************
	 * 	NAME: 			HitMessage
	 *  DESCRIPTION:	gets the ENEMY_HIT string
	 * 
	 * ********************************************************/
	public string HitMessage{
		get { return ENEMY_HIT;}
			
	}
}
