using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour {

	public void playGame() {
		print ("start");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void mainMenu() {
		print ("menu-ing");
		someVars.paused = false;
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
	}

	public void quitGame() {
		print ("end");
		Application.Quit ();
	}
}