using UnityEngine;
using System.Collections;

public class FPSInput : MonoBehaviour {

	public float speed = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;

		transform.Translate(deltaX,0,deltaZ);
	}
}
