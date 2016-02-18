using UnityEngine;
using System.Collections;


public class PauseMenu : MonoBehaviour
{

    private bool pause = false;
    private float x, y, width = 0.4f, height = 0.5f;

    //http://answers.unity3d.com/questions/139525/gui-in-the-middle-of-the-screen.html

    //private GameObject pauseMenu;
    //private Canvas canvas;

    // Use this for initialization
    void Start()
    {

        GameObject newCanvas = new GameObject("Canvas");

        Canvas c = newCanvas.AddComponent<Canvas>();

        c.renderMode = RenderMode.ScreenSpaceOverlay;

        //newCanvas.AddComponent<CanvasScaler>();
        //newCanvas.AddComponent<GraphicRaycaster>();

        GameObject panel = new GameObject("Panel");
        panel.AddComponent<CanvasRenderer>();
        //Image i = panel.AddComponent<Image>();
        //i.color = Color.red;

        panel.transform.SetParent(newCanvas.transform, false);

        //GameObject panel = new GameObject("panel");

        //pauseMenu = new GameObject("Pause Canvas");
        ///pauseMenu.AddComponent<Canvas>();

        //canvas.GetComponent<Canvas>();

        //canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        x = (Screen.width * (1 - width)) / 2;
        y = (Screen.height * (1 - height)) / 2;

        //panel.transform.SetParent(pauseMenu.transform, true);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) && !pause)
        {
            isPaused();
        }

    }

    private void isPaused()
    {
        if (!pause)
        {
            Time.timeScale = 0;
            pause = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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

    private void OnGUI()
    {

        float width = 500, height = 250;

        if (pause)
        {

            GUI.Box(new Rect(x, y, width,  height), "Pause Menu");


            if (GUI.Button(new Rect(x + 50, y + 50, 100, 20), "Paused"))
                isPaused();

            if (GUI.Button(new Rect(200, 230, 100, 20), "Exit"))
                Application.Quit();
        }


    }



}
