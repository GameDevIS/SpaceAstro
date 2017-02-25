// Website : GameDevIS (Youtube\Facebook)
// Written by GameDevIS <GameDevISR@gmail.com>, 20/02/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Text LivesText;						// Player Lives UI
	public float Score; 						// Player Score
	public Text ScoreText;						// UI Score Text
	public float scoreFactor;					// Score Factor Increment
	public Text GameOverScoreText;				// Game over score UI Text object
	public Transform GameOverPanel;				// UI Panel Displayed when game is over
	public PlayerController ourPlayer;			// Reference to our Player Script

	private bool isGameStarted;					// When isGameStarted is true Increment our player score

	// Use this for initialization
	void Start () {

		// Disable Cursor
		Cursor.visible = false;

		// When isGameStarted is true Increment our player score
		isGameStarted = true;

		// Get Our Player Script
		ourPlayer = GameObject.FindWithTag ("Player").GetComponent<PlayerController>();

		// Set Lives Text to player lives
		LivesText.text = "x " + ourPlayer.Lives;

	}
	
	// Update is called once per frame
	void Update () {

		// Update Lives Text to player lives
		LivesText.text = "x " + ourPlayer.Lives;

		// if our player lives = 0 and Player exist destroy player & end game
		if (ourPlayer.Lives == 0 && ourPlayer) {

			// Destroy ourPlayer game object
			Destroy (ourPlayer);

			// Show game over UI panel
			ShowGameOverPanel ();
		}

		// if game started increment our player score
		if (isGameStarted) {
			UpdateScore ();
		}

	}

	// Show GameOverPanel , Stop Time and Set Cursor to visible 
	void ShowGameOverPanel()
	{
		Time.timeScale = 0;
		isGameStarted = false;
		Cursor.visible = true;
		GameOverScoreText.text += Score.ToString ("F0");
		GameOverPanel.gameObject.SetActive (enabled);
	}

	// Update the scoreText element every delta time multiply scoreFactor
	void UpdateScore()
	{
		Score += Time.deltaTime * scoreFactor;
		ScoreText.text = "Score : " + Score.ToString("F0");
	}

	// Reload current scene and reset time Scale to 1
	public void PlayAgain()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
