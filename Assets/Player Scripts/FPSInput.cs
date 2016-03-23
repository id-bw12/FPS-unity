﻿using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour {

	public float speed = 3.0f, gravity  = -9.8f ;
	private CharacterController charController;

	// Use this for initialization
	void Start () {
		
		charController = GetComponent<CharacterController> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;

		var movement = new Vector3 (deltaX, 0, deltaZ);

		movement = Vector3.ClampMagnitude (movement, speed);
		movement.y = gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);

		charController.Move (movement);
	}

	float Speed{

		get{ return speed;}
		set{ speed = value;}
	}
}
