using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class externalScoreManager : MonoBehaviour {

	int score1;
	int score2;
	public GameObject goal1;
	public GameObject goal2;
	public Text scoreBoard1;
	public Text scoreBoard2;

	void Start() {
		score1 = goal1.GetComponent<goal> ().score;
		score2 = goal2.GetComponent<goal> ().score;
	}

	void FixedUpdate () {
		if (someVars.gameEnd == true) {
			score1 = 0;
			score2 = 0;
			scoreBoard1.text = "00";
			scoreBoard2.text = "00";
			someVars.gameEnd = false;
		}
	}
}