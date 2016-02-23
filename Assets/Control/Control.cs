using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	private Renderer[] render;

	private GameObject enemy, endingCube;

	private int enemyKilled = 0;

	private bool playerWins = false, goalObject = false;


	// Use this for initialization
	void Start () {

        Time.timeScale = 1;

		makeEnemy ();

		GameObject floor = GameObject.Find ("Floor");

		render = floor.GetComponentsInChildren<Renderer> ();

		for (int i = 0; i < render.Length; ++i) 
			render [i].material.color = Color.blue;

        GameObject gameLight = GameObject.Find("Directional Light");

        gameLight.transform.Rotate(50, 330, 0);

	}
	
	// Update is called once per frame
	void Update () {

		if (enemy == null && enemyKilled < 4) {
			makeEnemy ();
			++enemyKilled;

		} else if (enemyKilled == 4 && !goalObject) {
			endingCube = MakeGoalObject ();
            print("hey");
			goalObject = true;
		}
		else
			if (endingCube == null && goalObject)
				playerWins = true;
			
			
	}

	private GameObject MakeGoalObject(){
	
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
