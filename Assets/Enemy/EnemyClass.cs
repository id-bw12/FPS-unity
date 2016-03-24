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

public class EnemyClass : MonoBehaviour {

	protected Color enemyColor;

	protected int health;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/************************************************************
	 * 	NAME: 			SetColorToEnemy
	 *  DESCRIPTION:	Sets the enemys color to the saved color.
	 * 
	 * *********************************************************/
	protected void SetColorToEnemy(){
	
		this.GetComponent<MeshRenderer> ().material.color = enemyColor;

	}

	/**********************************************************
	 * 	NAME: 			SetAIPathing
	 *  DESCRIPTION:	Gives the enemy the AIMovement script
	 * 					as an component.
	 * 
	 * ********************************************************/
	public void SetAIPathing(){

		this.gameObject.AddComponent<AIMovement> ();
	}

	/**********************************************************
	 * 	NAME: 			ChangeSize
	 *  DESCRIPTION:	changes the enemy scale on the y axis 
	 * 					to 7.
	 * 
	 * ********************************************************/
	public void ChangeSize(){
	
		this.gameObject.transform.localScale += new Vector3 (0.0f, 7.0f, 0.0f);
	}
}
