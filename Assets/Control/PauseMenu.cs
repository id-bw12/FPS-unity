/**********************************************************
***********************************************************
***********************************************************
***														***
***						ID INFORMATION					***
***														***
***	Programmers				  :		  Eddie Meza Jr.	***
***	Assignment #			  :		  Program 4         ***
***	Assignment Name			  :		  GETTING GUI	    ***
*** Course # and Title		  :		  CISC 221			***
*** Class Meeting Time		  :		  TTH 09:35 - 12:45	***
*** Instructor				  :		  Professor Forman	***
*** Hours					  :		  10 				***
*** Difficulty				  :		  5 				***
*** Completion Date			  :		  03/23/2016		***
*** Project Name			  :		  FPS_unity		    ***
***														***
***********************************************************
***********************************************************
***														***
***			Program	Description 						***
***														***
***	  A demo to add a pause menu to the FPS game.	    ***
***   The program has the FPS projects full components. ***
***	  The pause menu can exit the game mode and change  ***
***	  the players and enemy speed.						***
***														***
***********************************************************
***********************************************************
***														***
***					Credits								***
***														***
***		Professor Forman's handout for making it easier ***
***		to compelte the TA.								***
***														***
***														***
***														***
***********************************************************
***********************************************************
***														***					
					Media

***														***
***********************************************************
***********************************************************
**********************************************************/

using UnityEngine;
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

		menuMaker.CreateText(panel.transform, new Vector2(10, 50), new Vector2(160, 50), "textHeader","Pause Menu", 14);

		menuMaker.CreateButton(panel.transform, new Vector2(0,-30), new Vector2(75,25), "Exitbttn","Exit", delegate {OnExit();});
        menuMaker.CreateButton(panel.transform, new Vector2(0, -05), new Vector2(75, 25), "OptionsBttn", "Options", delegate { Options(panel); });
		menuMaker.CreateButton(panel.transform, new Vector2(0, 20), new Vector2(75,25), "UnpauseBttn","Resume", delegate {ExitPause();});

	}
   
	private void OnExit(){
		UnityEditor.EditorApplication.isPlaying = false;
	}

    private void Options(GameObject panel) {

        var optionPanel = menuMaker.CreatePanel(GameObject.Find("Canvas").transform);

		float currentSpeed = GameObject.Find ("Player").GetComponent<FPSInput> ().Speed;

		var slider = menuMaker.CreateScaler(optionPanel.transform , new Vector2(-20,30), currentSpeed);

		menuMaker.CreateText(optionPanel.transform, new Vector2 (0, 50), new Vector2 (160,25), "speedHeaderLbl", "Players Speed", 12);
		menuMaker.CreateText (optionPanel.transform, new Vector2 (100, 30), new Vector2 (160,50), "SpeedLbl", currentSpeed.ToString(), 12);

        menuMaker.CreateButton(optionPanel.transform, new Vector2(0, -30), new Vector2(75, 25), "Backbttn", "back", delegate { Back(optionPanel); });

		slider.GetComponent<Slider> ().onValueChanged.AddListener (ValueChange);

		GameObject.Destroy(panel);

    }

    private void Back(GameObject panel) {
        GameObject.Destroy(panel);

        MakePauseMenu();

    }

    private void ExitPause(){

		isPaused ();

		GameObject.Destroy (GameObject.Find("Canvas"));
	}

	public void ValueChange(float value){

		var playerSpeed = GameObject.Find ("Player").GetComponent<FPSInput> ().Speed;

		Messenger<float>.Broadcast (new GameEvent ().SpeedMessage, value);

		GameObject.Find ("SpeedLbl").GetComponent<Text> ().text = playerSpeed.ToString ();
	}

}
