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

public class Level2Enemy : EnemyClass
{

	//private int health;


	// Use this for initialization
	void Start () {

		this.transform.localScale += new Vector3 (0.0f,2.0f,0.0f);

		this.transform.localPosition = new Vector3 (0,1,0);

	}

	// Update is called once per frame
	void Update () {

	}

	/**********************************************************
	 * 	NAME: 			Health
	 *  DESCRIPTION:	gets or sets the health variable.
	 * 
	 * ********************************************************/
	public int Health{
		get{ return health;}
		set{ health = value;}
	}

	/**********************************************************
	 * 	NAME: 			EnemyColor
	 *  DESCRIPTION:	gets or sets the color for the enemy
	 * 
	 * ********************************************************/
	public Color EnemyColor{
		get{ return enemyColor; }
		set{ enemyColor= value;}
	}

	/**********************************************************
	 * 	NAME: 			SetColor
	 *  DESCRIPTION:	Calls the SetColorToEnemy method from 
	 * 					this class parent class.
	 * 
	 * ********************************************************/
	public void SetColor(){
		SetColorToEnemy ();
	}
}

