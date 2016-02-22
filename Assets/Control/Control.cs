using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	private Renderer[] render;

	private GameObject enemy, endingCube;

	private int enemyKilled = 5;

	private bool playerWins = false;


	// Use this for initialization
	void Start () {
        
		endingCube = GoalObject ();

		//makeEnemy ();

		GameObject floor = GameObject.Find ("Floor");

		render = floor.GetComponentsInChildren<Renderer> ();

		for (int i = 0; i < render.Length; ++i) 
			render [i].material.color = Color.blue;

	}
	
	// Update is called once per frame
	void Update () {

		//if (enemy == null)
			//makeEnemy ();

		if (endingCube == null && enemyKilled == 5)
			playerWins = true;
			
			
	}

	private GameObject GoalObject(){
	
		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);

		Rigidbody cubeBody = cube.GetComponent<Rigidbody> ();

		BoxCollider cubeCollider = cube.GetComponent<BoxCollider> ();

		Renderer cubeRender = cube.GetComponent<Renderer> ();

		cube.transform.Rotate(50,0,0);

		cube.transform.localPosition = new Vector3 (0, 1, 0);

		cubeCollider.isTrigger = true;

		cube.AddComponent<GoalCube> ();

		cubeRender.material.color = Color.green;

		return cube;
	}

	private void makeEnemy(){

		float angle = Random.Range (0, 360);

		enemy = GameObject.CreatePrimitive (PrimitiveType.Cube);

		enemy.transform.localScale += new Vector3 (0.0f,2.0f,0.0f);

		enemy.transform.localPosition = new Vector3 (0,1,0);

		enemy.transform.Rotate(0, angle, 0);

		enemy.AddComponent<ReactiveTarget>();

		enemy.AddComponent<AIMovement> ();
	}

	public bool getWinCondition(){

		return playerWins;
	}
}
