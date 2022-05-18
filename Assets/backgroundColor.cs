using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundColor : MonoBehaviour {

	float h = 300f;
	float s = 100f;
	float v = 59f;

	void Update() {
		gameObject.GetComponent<SpriteRenderer> ().color = Color.HSVToRGB (h/360f, s/100f, v/100f);
		if (h > 0) {
			h -= .25f;
		} else if (h <= 0) {
			h = 360f;
		}
	}
}