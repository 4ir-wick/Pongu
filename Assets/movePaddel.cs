using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePaddel : MonoBehaviour {


	Rigidbody2D rBody;

	float vert;
	string axisDefine;

	public float speed;

	void Start() {
		if (gameObject.name == "paddle1") {
			axisDefine = "Vertical1";
		} else if (gameObject.name == "paddle2") {
			axisDefine = "Vertical2";
		}
		rBody = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		vert = Input.GetAxis (axisDefine);
	}

	void FixedUpdate () {
		rBody.velocity = new Vector2 (0, vert * speed);
	}
}