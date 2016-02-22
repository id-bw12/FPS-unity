using UnityEngine;
using System.Collections;

using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{

    private bool pause = false;
    private float x, y, width = 0.4f, height = 0.5f;

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
	
		UIMakerScript menuMaker = new UIMakerScript ();

		GameObject canvas = menuMaker.CreateCanvas(this.transform);

		menuMaker.CreateEventSystem(canvas.transform);

		GameObject panel = menuMaker.CreatePanel(canvas.transform);

		menuMaker.CreateText(panel.transform, 0, 50, 160, 50, "Message", 14);
		menuMaker.CreateText(panel.transform, 0, 25, 160, 50, "Are you sure, you want to exit?", 12);

		GameObject button1 = menuMaker.CreateButton(panel.transform, 0, -40, 160, 25, "Yes", delegate {OnExit();});
		GameObject button2 = menuMaker.CreateButton(panel.transform, 0, 10, 160, 25, "No", delegate {OnCancel();});


	}
   
	private void OnExit(){

		Debug.Log ("Exit");
		Application.Quit();
	}

	private void OnCancel(){
		
		Debug.Log ("Don't");

		PauseMenu pause = gameObject.GetComponent <PauseMenu>();

		isPaused ();

		GameObject.Destroy (GameObject.Find("Canvas"));
	}

}
