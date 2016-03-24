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

public class ReactiveTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	/**********************************************************
	 * 	NAME: 			ReactToHit
	 *  DESCRIPTION:	Checks to see if the bullet hits an 
	 * 					enemy. If true then lower the enemy's
	 * 					health and check if its health is zero.
	 * 					If true then call the Die method.
	 * 
	 * ********************************************************/
	public void ReactToHit(){
		AIMovement behavior = GetComponent<AIMovement> ();

		if (behavior != null) {
			Level2Enemy enemy = GetComponent<Level2Enemy> ();

			enemy.Health -= 1;
			if(enemy.Health == 0){
				behavior.SetAlive (false);

				StartCoroutine (Die());
			}

		}
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/**********************************************************
	 * 	NAME: 			Die
	 *  DESCRIPTION:	Rotates the enemy -75 or 285 degrees on 
	 * 					the x axis and destorys it after 1.5 
	 * 					seconds.
	 * 
	 * ********************************************************/
	private IEnumerator Die(){
		this.transform.Rotate (-75, 0, 0);

		yield return new WaitForSeconds (1.5f);

		Destroy (this.gameObject);
	}
}
