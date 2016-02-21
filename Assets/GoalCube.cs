using UnityEngine;
using System.Collections;

public class GoalCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.transform.Rotate (5, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0, 0, 5);
	}

	void OnTriggerEnter(Collider other){
		PlayerCharacter player = other.GetComponent<PlayerCharacter> ();

		if (player != null)
			Debug.Log ("dfd");

		Destroy (this.gameObject);
	} 
}
