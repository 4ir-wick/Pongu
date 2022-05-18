using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake_sprite : MonoBehaviour {

	Vector2 ponguOrigin;

	void Start () {
		ponguOrigin = new Vector2 (transform.position.x, transform.position.y);
	}
	void Update () {
		transform.position = Random.insideUnitCircle * 5 + ponguOrigin;
	}
}