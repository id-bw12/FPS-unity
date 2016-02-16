using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	private int health = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (this.health == 0) {
            print("Game over.");
            Time.timeScale = 0;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
	
	}

	public void Hurt(int damage){
		health -= damage;
		Debug.Log ("health: " + this.health);
	}
}
