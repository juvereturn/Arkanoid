using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TrueAxion.Arkanoid
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }


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

        [SerializeField]
        private UIManager uiManager;

        //Store the bricks on the scene to track whether the game will end or not
        [HideInInspector] public List<Brick> brickList = new List<Brick>();

        //Track the game state
        [HideInInspector] public bool gameOver = false;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            if (PlayerPrefs.HasKey("HighScore"))
            {
                highScore = PlayerPrefs.GetInt("HighScore");
            }
            else
            {
                highScore = 0;
            }
            uiManager.UpdateScore(score);
            uiManager.UpdateHighScore(highScore);
        }

        void Update()
        {
            UpdateUIText();
            CheckGameState();
        }

        /// <summary>
        /// Destroy a brick from the brickList(Call When the brick is destroyed)
        /// </summary>
        /// <param name="brick"></param>
        public void DestroyABrick(Brick brick)
        {
            if (brickList.Contains(brick))
            {
                brickList.Remove(brick);
            }
        }

        //Add score, if the score>highscore, update highscore
        public void AddScore(int amount)
        {
            score += amount;
            uiManager.UpdateScore(score);
        }

        //Update UI text
        void UpdateUIText()
        {
            livesNumberUI.text = PlayerController.Instance.GetCurrentLife().ToString();
        }

        //Check if the game is over
        public void CheckGameOver()
        {
            if (PlayerController.Instance.GetCurrentLife() <= 0)
            {
                gameOver = true;
                gameOverUI.SetActive(true);
            }
        }

        //Load The Game Scene Again When The Players Win Or Lose
        public void CheckGameState()
        {
            if (brickList.Count <= 0) //If all bricks are destroyed, load the scene and continue playing
            {
                RestartGame();
            }

            //When the game is over, players can press space to reset the score and play again
            if (gameOver)
            {
                if (Input.GetKeyDown("space"))
                {
                    score = 0;
                    RestartGame();
                }
            }
        }

        void RestartGame()
        {
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
            uiManager.UpdateHighScore(highScore);
            SceneManager.LoadScene("ArkanoidGameScene");
        }

    }
}

