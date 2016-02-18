using UnityEngine;
using System.Collections;

public class GunMechanic : MonoBehaviour {
	
	private Camera _camera;
    

	// Use this for initialization
	void Start () {
		_camera = GetComponent<Camera>();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void OnGUI(){
		int size = 12;
		float posX = _camera.pixelWidth / 2 - size / 4;
		float posY = _camera.pixelHeight / 2 - size / 4;

		GUI.Label (new Rect (posX, posY, size, size), "*");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && Time.timeScale != 0){
			var point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
			var ray = _camera.ScreenPointToRay (point);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				var hitObject = hit.transform.gameObject;
				var target = hitObject.GetComponent<ReactiveTarget> ();

				if (target != null)
					target.ReactToHit ();
				else 
					StartCoroutine (SphereIndictor (hit.point));
					
			}
				
		}
	}

	private IEnumerator SphereIndictor(Vector3 pos){
		var sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);

		sphere.transform.position = pos;

		yield return new WaitForSeconds (0.5f);

		Destroy (sphere);
	}
}
