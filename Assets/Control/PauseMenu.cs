﻿using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEditor;


public class PauseMenu : MonoBehaviour
{

    private bool pause = false;
    private float x, y, width = 0.4f, height = 0.5f;
    private GameObject canvas;

    private UIMakerScript menuMaker = new UIMakerScript();

    //http://answers.unity3d.com/questions/139525/gui-in-the-middle-of-the-screen.html

    void Start(){

        x = (Screen.width * (1 - width)) / 2;
        y = (Screen.height * (1 - height)) / 2;


    }

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyDown(KeyCode.P) && !pause)
            isPaused();


    }

    private void isPaused(){

        if (!pause){
			
            Time.timeScale = 0;
            pause = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            canvas = menuMaker.CreateCanvas(this.transform);

            menuMaker.CreateEventSystem(canvas.transform);

            MakePauseMenu ();

        }
        else
        if (pause){
				
            Time.timeScale = 1;
            pause = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }

    }

	private void MakePauseMenu(){

		GameObject panel = menuMaker.CreatePanel(canvas.transform);

		menuMaker.CreateText(panel.transform, new Vector2(0, 50), new Vector2(160, 50), "textHeader","Pause Menu", 14);
		menuMaker.CreateText(panel.transform, new Vector2(0, 25), new Vector2(160, 50), "subText","Are you sure, you want to exit?", 12);

		GameObject button1 = menuMaker.CreateButton(panel.transform, new Vector2(0,0), new Vector2(75,25), "Exitbttn","Yes", delegate {OnExit();});
        GameObject button2 = menuMaker.CreateButton(panel.transform, new Vector2(0, -25), new Vector2(75, 25), "OptionsBttn", "Options", delegate { Options(panel); });
		GameObject button3 = menuMaker.CreateButton(panel.transform, new Vector2(0, -50), new Vector2(75,25), "UnpauseBttn","No", delegate {ExitPause();});


	}
   
	private void OnExit(){
		
		Debug.Log ("Exit");
		UnityEditor.EditorApplication.isPlaying = false;
	}

    private void Options(GameObject panel) {

        GameObject.Destroy(panel);

        var optionPanel = menuMaker.CreatePanel(GameObject.Find("Canvas").transform);

        menuMaker.CreateScaler(optionPanel.transform , new Vector2(0,30));

        GameObject button1 = menuMaker.CreateButton(optionPanel.transform, new Vector2(0, -30), new Vector2(75, 25), "Backbttn", "back", delegate { Back(optionPanel); });

    }

    private void Back(GameObject panel) {
        GameObject.Destroy(panel);

        MakePauseMenu();

    }

    private void ExitPause(){
		
		Debug.Log ("Unpaused");

		isPaused ();

		GameObject.Destroy (GameObject.Find("Canvas"));
	}

}
