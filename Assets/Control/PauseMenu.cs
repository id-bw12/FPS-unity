using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private bool pause = false;
	//private GUI pausedMenu;

	// Use this for initialization
	void Start () {

        //GameObject canvas  = new GameObject("canvas", typeof(RectTransform));
        //canvas.AddComponent<Canvas>();

        print(Screen.width);

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

        float x = 150, y = 60, width = 500, height = 250;

        if (pause)
        {

            GUI.Box(new Rect(x, y, width, height), "Pause Menu");


            if (GUI.Button(new Rect(200, 200, 100, 20), "Paused"))
                isPaused();

            if (GUI.Button (new Rect (200, 230, 100, 20), "Exit"))
				Application.Quit ();
			}


	}



}
