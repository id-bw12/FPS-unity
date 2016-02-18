using UnityEngine;
using System.Collections;

public class FullScreen : MonoBehaviour {

	private bool fullScreen = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.F)) {
			
			if (!fullScreen) {
				Screen.SetResolution (640, 480, true);
				fullScreen = true;
			} else if (fullScreen) {
				Screen.SetResolution (500, 250, false);
				fullScreen = false;
			}
		}
	}
}
