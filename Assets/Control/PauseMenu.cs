using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private bool pause = false;
    private float x , y;

    //http://answers.unity3d.com/questions/139525/gui-in-the-middle-of-the-screen.html

    //private GUI pausedMenu;

    // Use this for initialization
    void Start () {

        //GameObject canvas  = new GameObject("canvas", typeof(RectTransform));
        //canvas.AddComponent<Canvas>();

        print(Screen.width);

        if (Screen.width > 1004){
            x = Screen.width / 1.5f;
            y = Screen.height / 1.25f;
        }
        else if(Screen.width <= 1004){
           
            x = Screen.width / 1.25f;
            y = Screen.height / 1.25f;
        }

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

        float width = 500, height = 250;

        if (pause)
        {

            GUI.Box(new Rect(Screen.width - x, Screen.height - y, width, height), "Pause Menu");


            if (GUI.Button(new Rect(x+50, y+50, 100, 20), "Paused"))
                isPaused();

            if (GUI.Button (new Rect (200, 230, 100, 20), "Exit"))
				Application.Quit ();
			}


	}



}
