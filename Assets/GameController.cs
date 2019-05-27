using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public PlayerController player;

	public GameObject[] lives = new GameObject[4];

	public GameObject gameOverMessage;
	public GameObject resetButton;

	//public Text scoreText;
	//private int score = 0;

	// Use this for initialization
	void Start () {
		GameOver(false);
	}
	
	// Update is called once per frame
	void Update () {
		UpdateLifes();
	}

	void UpdateLifes(){
		for(int i = 0; i <= lives.Length -1; i++){
			if(i < player.lives){
				lives[i].SetActive(true);
			} else {
				lives[i].SetActive(false);
			}
		}
		
	}

	public void GameOver(bool gameStatus){
		gameOverMessage.SetActive(gameStatus);
		resetButton.SetActive(gameStatus);
		if(gameStatus == true){
			Time.timeScale = 0f;
		}
		if(gameStatus == false){
			Time.timeScale = 1f;
		}
	}

	public void Reset(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	// public void AddToScore(int scoreToAdd){
	// 	if(scoreToAdd > 0){
	// 		score = score + scoreToAdd;
	// 	} else if(score - scoreToAdd >= 0){
	// 		score = score - scoreToAdd;
	// 	} else {
	// 		score = 0;
	// 	}
	// }

	void UpdateScoreText(){
		//scoreText.Text = "Score: " + score;
	}
}
