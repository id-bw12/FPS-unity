using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private bool pause = false;
	private GUI pausedMenu;

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

			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
        }
        else
        if (pause){
            Time.timeScale = 1;
            pause = false;
			
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
        }

	}

	private void OnGUI(){
	
		if (pause) {
			
			GUI.Box (new Rect (10,20,1000,1000), "Pause Menu");

			if (GUI.Button (new Rect (100, 200, 100, 20), "Paused"))
				isPaused ();
			
			if (GUI.Button (new Rect (100, 230, 100, 20), "Exit"))
				Application.Quit ();
			}
	}

}
