using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [Tooltip("the initial speed of the ball")]
    public float speed = 200f;

    //Check if the ball is still attached to players or not
    private bool ballInPlay = false;

    //min and max of viewport for checking if the projectile is off-screen 
    Vector2 minViewport;

    GameManager gameManager;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        //Get The Viewport EveryFrame, and check if the ball is offscreeen
        minViewport = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        DestroyOnOffScreen();

        //Press Space to detach and shoot the ball
        if (Input.GetKeyDown(KeyCode.Space) && ballInPlay == false) {
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
            gameManager.activePlayer.lives--;

            //Check whether if players have life <= 0 (if life <= 0, the game is over)
            gameManager.CheckGameOver();

            //Ignore the respawn process if the game is over
            if (gameManager.gameOver)
            {
                return;
            }

            //Respawn ball at the ball spawn position
            gameManager.activePlayer.RespawnBall();
        }
    }
}
