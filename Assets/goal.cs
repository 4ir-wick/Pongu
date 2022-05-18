using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goal : MonoBehaviour {

	public Text scoreBoard;
	public GameObject paddleColor;
	public GameObject winText;
	public GameObject paddleLocal;
	public GameObject paddleOther;
	public int score = 0;
	int downTime = 3;
	int maxScore = 6;

	public GameObject ball;

	bool debounce = false;

	void OnTriggerEnter2D(Collider2D other) {
		StartCoroutine(theMeat());
	}

	IEnumerator theMeat() {
		if (debounce == false) {
			debounce = true;
			someVars.scored = true;
			score += 1;
			if (score < maxScore) {
				scoreBoard.text = ("0" + score.ToString ());
			} else if (score == maxScore) {
				scoreBoard.text = ("0" + score.ToString());
				if (paddleLocal.name == "paddle1") {
					paddleColor.GetComponent<Text>().text = "green";
					paddleColor.GetComponent<Text> ().color = new Color (0, 255f/255f, 0);
					paddleColor.GetComponent<Outline> ().effectColor = new Color (0, 165f/255f, 0);
				} else if (paddleLocal.name == "paddle2") {
					paddleColor.GetComponent<Text>().text = "blue";
					paddleColor.GetComponent<Outline> ().effectColor = new Color (0, 165f/255f, 165f/255f);
					paddleColor.GetComponent<Text> ().color = new Color (0, 255f/255f, 255f/255f);
				}
				paddleColor.SetActive (true);
				winText.SetActive (true);
				ball.SetActive (false);
				someVars.gameEnd = true;
			}

			ball.transform.position = new Vector3 (0, -0.75f, 0);
			ball.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			ball.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePosition;
			paddleLocal.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			paddleLocal.transform.position = new Vector3 (paddleLocal.transform.position.x, -0.75f, 0);
			paddleLocal.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePosition;
			paddleOther.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			paddleOther.transform.position = new Vector3 (paddleOther.transform.position.x, -0.75f, 0);
			paddleOther.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePosition;
			yield return new WaitForSeconds (downTime);
			paddleColor.SetActive (false);
			winText.SetActive (false);
			ball.SetActive (true);
			ball.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			ball.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
			paddleLocal.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			paddleLocal.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			paddleOther.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			paddleOther.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			if (ball.GetComponent<ballPhysics> ().speed > 0) {
				ball.GetComponent<ballPhysics> ().speed = ball.GetComponent<ballPhysics> ().initialSpeed;
			} else if (ball.GetComponent<ballPhysics> ().speed < 0) {
				ball.GetComponent<ballPhysics> ().speed = -ball.GetComponent<ballPhysics> ().initialSpeed;
			}
			ball.GetComponent<ballPhysics> ().vertSpeed = 0;
			someVars.scored = false;
			debounce = false;
		}
	}
}