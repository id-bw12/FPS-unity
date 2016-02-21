using UnityEngine;
using System.Collections;

using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{

    private bool pause = false;
    private float x, y, width = 0.4f, height = 0.5f;

    //http://answers.unity3d.com/questions/139525/gui-in-the-middle-of-the-screen.html

    void Start()
    {

        x = (Screen.width * (1 - width)) / 2;
        y = (Screen.height * (1 - height)) / 2;


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) && !pause)
            isPaused();


    }

    private void isPaused(){

        if (!pause){
			
            Time.timeScale = 0;
            pause = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

			this.gameObject.AddComponent<UIMakerScript> ();

        }
        else
        if (pause)
        {
            Time.timeScale = 1;
            pause = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

		
        }

    }

   



}
