using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	// Use this for initialization
	void Start () {

		var cube = GameObject.CreatePrimitive (PrimitiveType.Cube);

		cube.transform.localScale += new Vector3 (0.0f,2.0f,0.0f);

		cube.transform.localPosition = new Vector3 (0,1,0);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
