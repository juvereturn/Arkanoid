using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TrueAxion.Arkanoid
{
    public class UIManager : MonoBehaviour
    {
        [Tooltip("GameOverUI At the Middle canvas")]
        [SerializeField] private GameObject gameOverUI;

        [Tooltip("livesNumberUI At the Right canvas")]
        [SerializeField] private Text livesNumberUI;
        [Tooltip("HighscoreNumberUI At the Right canvas")]
        [SerializeField] private Text highScoreNumberUI;
        [Tooltip("scoreNumberUI At the Right canvas")]
        [SerializeField] private Text scoreNumberUI;

        /// <summary>
        /// Update Lives Number UI on the screen when health's value is changed.
        /// </summary>
        /// /// <param name="lives"></param>
        public void UpdateLivesNumberUI(int lives)
        {
            livesNumberUI.text = lives.ToString();
        }

        /// <summary>
        /// Update Score UI on the screen when score's value is changed.
        /// </summary>
        /// <param name="score"></param>
        public void UpdateScore(int score)
        {
            scoreNumberUI.text = score.ToString();
        }

        /// <summary>
        /// Update HighScpre UI on the screen when highscore's value is changed.
        /// </summary>
        /// <param name="highscore"></param>
        public void UpdateHighScore(int highscore)
        {
            highScoreNumberUI.text = highscore.ToString();
        }

        /// <summary>
        /// Set active to GameOver UI that will be shown or not.
        /// </summary>
        /// <param name="value"></param>
        public void SetGameOverEnable(bool value)
        {
            gameOverUI.SetActive(value);
        }

    }
}