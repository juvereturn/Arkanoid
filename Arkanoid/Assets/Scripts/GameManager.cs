using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
    [Tooltip("GameOverUI At the Middle canvas")]
    public GameObject gameOverUI;

    [Tooltip("HighscoreNumberUI At the Right canvas")]
    public Text highScoreNumberUI;
    [Tooltip("scoreNumberUI At the Right canvas")]
    public Text scoreNumberUI;
    [Tooltip("livesNumberUI At the Right canvas")]
    public Text livesNumberUI;

    static int score;
    int highScore;

    [Tooltip("Store the active player character in the scene")]
    public PlayerController activePlayer;

    //Store the bricks on the scene to track whether the game will end or not
    [HideInInspector] public List<Brick> brickList;

    //Track the game state
    [HideInInspector]public bool gameOver = false;

	void Start () {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else {
            highScore = 0;
        }

        foreach (Brick enemy in FindObjectsOfType<Brick>())
        {
            brickList.Add(enemy);
        }
    }
	
	void Update () {
        UpdateUIText();
        CheckGameState();
    }

    //Add score, if the score>highscore, update highscore
    public void AddScore(int amount) {
        score += amount;
        if (score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    //Update UI text
    void UpdateUIText() {
        scoreNumberUI.text = score.ToString();
        livesNumberUI.text = activePlayer.lives.ToString();
        highScoreNumberUI.text = highScore.ToString();
    }

    //Check if the game is over
    public void CheckGameOver() {
        if (activePlayer.lives <= 0) {
            gameOver = true;
            gameOverUI.SetActive(true);
        }
    }

    //Load The Game Scene Again When The Players Win Or Lose
    public void CheckGameState() {
        if (brickList.Count <= 0) //If all bricks are destroyed, load the scene and continue playing
        {
            SceneManager.LoadScene("ArkanoidGameScene");
        }

        //When the game is over, players can press space to reset the score and play again
        if (gameOver) {
            if (Input.GetKeyDown("space")) {
                score = 0;
                SceneManager.LoadScene("ArkanoidGameScene");
            }
        }
    }

}
