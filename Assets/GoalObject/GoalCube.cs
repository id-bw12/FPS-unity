using UnityEngine;
using System.Collections;

public class GoalCube : MonoBehaviour {

	private PauseMenu isPause;

	// Use this for initialization
	void Start () {

		GameObject control = GameObject.Find ("GameControl");

		isPause = control.GetComponent<PauseMenu> ();

		this.transform.Rotate (5, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.timeScale == 1)
			this.transform.Rotate (0, 0, 5);
	}

	void OnTriggerEnter(Collider other){
		PlayerCharacter player = other.GetComponent<PlayerCharacter> ();

		if (player != null)
			Debug.Log ("dfd");

		Destroy (this.gameObject);
	} 
}
