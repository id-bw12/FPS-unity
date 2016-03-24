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

public class AIMovement : MonoBehaviour {

	public float speed = 3.0f, baseSpeed = 3.0f,obstacleRange = 5.0f;
	private bool alive = true;
	private GameObject fireball;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (alive) {
			transform.Translate (0, 0, speed * Time.deltaTime);

			var ray = new Ray (transform.position, transform.forward);
	
			RaycastHit hit;

			if (Physics.SphereCast (ray, 0.75f, out hit)){
				GameObject hitObject = hit.transform.gameObject;
				if (hitObject.GetComponent<PlayerCharacter> ()) {
					if (fireball == null) {
						fireball = MakeFireball ();

						fireball.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
						fireball.transform.rotation = transform.rotation;
			
					}
				}
			}
			else if (hit.distance < obstacleRange) {

				float angle = Random.Range (-110, 110);
				transform.Rotate (0, angle, 0);
			}
		}
	}


	/**********************************************************
	 * 	NAME: 			SetAlive 
	 *  DESCRIPTION:	Sets the alive boolean by the variable 
	 * 					given.
	 * 
	 * ********************************************************/
	public void SetAlive(bool alive){
		this.alive = alive;

	}

	/**********************************************************
	 * 	NAME: 			MakeFireBall
	 *  DESCRIPTION:	Make the fireball the enmy uses and sets
	 * 					the components and the boolen variables 
	 * 					in two of those components. Then returns
	 * 					the firball object.
	 * 
	 * ********************************************************/

	private GameObject MakeFireball(){
		var sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);

		sphere.AddComponent<Rigidbody> ().useGravity = false;

		sphere.AddComponent<SphereCollider> ().isTrigger = true;

		sphere.AddComponent<Fireball> ();

		sphere.GetComponent<Renderer>().material.color = Color.magenta;

		return sphere;
	}

	/**********************************************************
	 * 	NAME: 			OnSpeedChanged
	 *  DESCRIPTION:	Changes the enemy's movement speed by
	 * 					multipling the base speed by the value 
	 * 					given.
	 * 
	 * ********************************************************/

	public void Awake(){
		Messenger<float>.AddListener (new GameEvent ().SpeedMessage, OnSpeedChanged);
	}

	/**********************************************************
	 * 	NAME: 			OnSpeedChanged
	 *  DESCRIPTION:	Changes the enemy's movement speed by
	 * 					multipling the base speed by the value 
	 * 					given.
	 * 
	 * ********************************************************/

	public void OnDestory(){
		Messenger<float>.AddListener (new GameEvent ().SpeedMessage, OnSpeedChanged);
	}

	/**********************************************************
	 * 	NAME: 			OnSpeedChanged
	 *  DESCRIPTION:	Changes the enemy's movement speed by
	 * 					multipling the base speed by the value 
	 * 					given.
	 * 
	 * ********************************************************/
	private void OnSpeedChanged(float value){
	
		speed = baseSpeed * value;
	}

}
