using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrueAxion.Arkanoid
{
    public class Ball : MonoBehaviour
    {
        [Tooltip("the initial speed of the ball")]
        public float speed = 200f;

        //Check if the ball is still attached to players or not
        private bool ballInPlay = false;

        //min and max of viewport for checking if the projectile is off-screen 
        Vector2 minViewport;

        private Rigidbody2D rb;

        private BallBouncingCalculator ballBouncingCalculator;

        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            ballBouncingCalculator = GetComponent<BallBouncingCalculator>();
        }

        // Update is called once per frame
        void Update()
        {
            //Get The Viewport EveryFrame, and check if the ball is offscreeen
            minViewport = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            DestroyOnOffScreen();

            //Press Space to detach and shoot the ball
            if (Input.GetKeyDown(KeyCode.Space) && ballInPlay == false)
            {
                transform.parent = null;
                ballInPlay = true;
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.AddForce(new Vector2(speed, speed));
            }
        }

        //Destroy The Projectile If It's off-screen
        void DestroyOnOffScreen()
        {
            if (transform.position.y < minViewport.y)
            {
                //Destroy the ball,and subtract 1 life from the player
                Destroy(gameObject);
                PlayerController.Instance.DecreaseALife();

                //Check whether if players have life <= 0 (if life <= 0, the game is over)
                GameManager.Instance.CheckGameOver();

                //Ignore the respawn process if the game is over
                if (GameManager.Instance.gameOver)
                {
                    return;
                }

                //Respawn ball at the ball spawn position
                PlayerController.Instance.RespawnBall();
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            //Call PlayerBall Collision if it hits a ball
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Wall")
            {
                ballBouncingCalculator.CalculateBallBouncing(collision.contacts[0].point, (Vector2)collision.gameObject.transform.position);
            }
        }
    }
}