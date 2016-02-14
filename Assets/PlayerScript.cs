using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float speed = 6.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0,speed,0);
	}
}
