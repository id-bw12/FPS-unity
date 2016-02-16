using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour {

	public float speed = 3.0f, obstacleRange = 5.0f;
	private bool alive = true;
	private GameObject fireball;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (alive) {
			transform.Translate (0, 0, speed * Time.deltaTime);

			var ray = new Ray (transform.position, transform.forward);
	
			RaycastHit hit;

			if (Physics.SphereCast (ray, 0.75f, out hit)){
				GameObject hitObject = hit.transform.gameObject;
				if (hitObject.GetComponent<PlayerCharacter> ()) {
					if (fireball == null) {
						fireball = makeFireball ();

						fireball.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
						fireball.transform.rotation = transform.rotation;
			
					}
				}
			}
			else if (hit.distance < obstacleRange) {

				float angle = Random.Range (-110, 110);
				transform.Rotate (0, angle, 0);
			}
		}
	}

	public void isAlive(bool alive){
		this.alive = alive;

	}

	private GameObject makeFireball(){
		var sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		var rander = sphere.GetComponent<Renderer>();

		sphere.AddComponent<Rigidbody> ();
		sphere.AddComponent<SphereCollider> ();

		var rigidBody = sphere.GetComponent<Rigidbody> ();
		var sphereCollider = sphere.GetComponent<SphereCollider> ();

		rander.material.color = Color.magenta;

		sphereCollider.isTrigger = true;

		rigidBody.useGravity = false;

		sphere.AddComponent<Fireball> ();

		return sphere;
	}

}
