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

public class Fireball : MonoBehaviour {

	public float speed = 10.0f;
	public int damage = 1;

	// Use this for initialization
	void Start () {

		this.gameObject.transform.localScale = new Vector3 (0.25f, 0.25f, 0.25f);
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0,0, speed*Time.deltaTime);
	}

	/**********************************************************
	 * 	NAME: 			OnTriggerEnter
	 *  DESCRIPTION:	Checks to whether the player and the 
	 * 					fireball have collided. If so then call
	 * 					the hurt method and destory the fireball.
	 * 
	 * ********************************************************/
	void OnTriggerEnter(Collider other){
		PlayerCharacter player = other.GetComponent<PlayerCharacter> ();

		if (player != null){
			player.Hurt (damage);
		}
		Destroy (this.gameObject);
	} 
}
