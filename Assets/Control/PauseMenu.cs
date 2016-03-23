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

		menuMaker.CreateText(panel.transform, new Vector2(0, 50), new Vector2(160, 50), "textHeader","Pause Menu", 14);

		GameObject button1 = menuMaker.CreateButton(panel.transform, new Vector2(0,-30), new Vector2(75,25), "Exitbttn","Exit", delegate {OnExit();});
        GameObject button2 = menuMaker.CreateButton(panel.transform, new Vector2(0, -05), new Vector2(75, 25), "OptionsBttn", "Options", delegate { Options(panel); });
		GameObject button3 = menuMaker.CreateButton(panel.transform, new Vector2(0, 20), new Vector2(75,25), "UnpauseBttn","Resume", delegate {ExitPause();});


	}
   
	private void OnExit(){
		
		Debug.Log ("Exit");
		UnityEditor.EditorApplication.isPlaying = false;
	}

    private void Options(GameObject panel) {

        GameObject.Destroy(panel);

        var optionPanel = menuMaker.CreatePanel(GameObject.Find("Canvas").transform);

		var currentSpeed = GameObject.Find ("Player").GetComponent<FPSInput> ();

		var slider = menuMaker.CreateScaler(optionPanel.transform , new Vector2(0,30), currentSpeed.speed);

        GameObject button1 = menuMaker.CreateButton(optionPanel.transform, new Vector2(0, -30), new Vector2(75, 25), "Backbttn", "back", delegate { Back(optionPanel); });

		slider.GetComponent<Slider> ().onValueChanged.AddListener (ValueChange);

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

	public void ValueChange(float value){
	
		FPSInput playerSpeed = GameObject.Find ("Player").GetComponent<FPSInput> ();

		Slider gameSlider = GameObject.Find ("Slider").GetComponent<Slider> ();

		playerSpeed.speed = value;

		Debug.Log (playerSpeed.speed);

	}

}
