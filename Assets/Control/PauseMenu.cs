using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private bool pause = false;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.P) && !pause) {
			isPaused ();
		}


	}

	private void isPaused(){
        if (!pause)
        {
            Time.timeScale = 0;
            pause = true;
        }
        else
        if (pause){
            Time.timeScale = 1;
            pause = false;
        }

	}

	private void OnGUI(){
	
		if (pause) {
			GUILayout.BeginArea(new Rect(100,120,200,200));
			GUILayout.Label("Game is paused!");


			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;

			if (GUILayout.Button ("Click me to unpause")) {
				isPaused ();

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
			}

		}
	}

}
