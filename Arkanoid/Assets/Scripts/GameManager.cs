using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public GameObject gameOverUI;

    public Text highScoreNumberUI;
    public Text scoreNumberUI;
    public Text livesNumberUI;

    static int score;
    int highScore;

    public PlayerController activePlayer;

    [HideInInspector]public BrickSpawner brickSpawner;

    //Track the game state
    [HideInInspector]public bool gameOver = false;

	// Use this for initialization
	void Start () {
        brickSpawner = FindObjectOfType<BrickSpawner>();
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else {
            highScore = 0;
        }
    }
	
	// Update is called once per frame
	void Update () {
        UpdateUIText();
        CheckGameState();
    }

    public void AddScore(int amount) {
        score += amount;
        if (score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    void UpdateUIText() {
        scoreNumberUI.text = score.ToString();
        livesNumberUI.text = activePlayer.lives.ToString();
        highScoreNumberUI.text = highScore.ToString();
    }

    public void CheckDeath() {
        if (activePlayer.lives <= 0) {
            gameOver = true;
            gameOverUI.SetActive(true);
        }
    }

    public void CheckGameState() {
        if (brickSpawner.bricks.Count <= 0) //If all bricks are destroyed, load the scene and continue playing
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
