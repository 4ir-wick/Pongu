using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballPhysics : MonoBehaviour {

	public float initialSpeed;
	public float increasePerTouch;
	public float speed;
	public float vertSpeed;
	Rigidbody2D rBody;
	int[] initialDirections = new int[] {-1,1};

	void Start () {
		speed = initialDirections [Random.Range (0, initialDirections.Length)] * initialSpeed;
		rBody = GetComponent<Rigidbody2D> ();
		rBody.velocity = new Vector2 (speed, 0);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag ("Paddle")) {
			if (speed > 0) {
				speed += increasePerTouch;
			} else if (speed < 0) {
				speed -= increasePerTouch;
			}
			speed = -speed;
			vertSpeed = (coll.gameObject.GetComponent<Rigidbody2D> ().velocity.y / 2) + Random.Range (-3, 3);
		} else if (coll.gameObject.CompareTag ("Boundary")) {
				vertSpeed = -vertSpeed;
		}
	}

	void FixedUpdate() {
		if (someVars.scored == false) {
			rBody.velocity = new Vector2 (speed, vertSpeed);
		}
	}
}