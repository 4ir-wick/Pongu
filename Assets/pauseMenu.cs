using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {

	public GameObject pMenu;
	static int counter = 0;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && counter >= 10) {
			counter = 0;
			if (someVars.paused == true) {
				resume ();
			} else {
				pause();
			}
		}
		if (counter < 10) {
			counter += 1;
		}
	}

	void resume() {
		pMenu.SetActive (false);
		Time.timeScale = 1f;
		someVars.paused = false;
	}

	void pause() {
		pMenu.SetActive (true);
		Time.timeScale = 0f;
		someVars.paused = true;
	}
}