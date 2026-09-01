using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
	private int score;
	private int lives;
	public int perfect = 0;
	public Text ScoreText;
	public Text LivesText;
	public Text ReloadText;
	public GameObject RestartButton;
	// Use this for initialization
	void Start () {
		score = 0;
		lives = 3;
		ScoreText.text = "Score: " + score.ToString ();
		LivesText.text = "Lives: " + lives.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ResetPerfect(){
		perfect = 0;
	}

	public void UpdateScore(){
		score = score + 1;
		ScoreText.text = "Score: " + score.ToString ();
		perfect++;

		 
		if (perfect == 2) {
			lives = lives + 1;
			LivesText.text = "Lives: " + lives.ToString ();
			ReloadText.text = "PERFECT";
			ReloadText.gameObject.SetActive (true);
		}
	}
	public void UpdateLives(){
		ResetPerfect ();
		lives = lives - 1;
		LivesText.text = "Lives: " + lives.ToString ();
		if (lives == 0) {
			ReloadText.text = "GAME OVER";
			ReloadText.gameObject.SetActive (true);
			RestartButton.gameObject.SetActive (true);
			Destroy(GameObject.Find("Cannon"));
			Destroy(GameObject.Find("BurgerLauncher"));
			Destroy(GameObject.Find("BurgerLauncher2"));

		}


	}


}


