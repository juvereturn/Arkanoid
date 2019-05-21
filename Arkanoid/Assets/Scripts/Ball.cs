using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed = 200f;

    private Rigidbody2D rb;
    private bool ballInPlay = false;

    public PlayerController player;

    //min and max of viewport for checking if the projectile is off-screen 
    Vector2 minViewport;

    GameManager gameManager;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        //Get The Viewport EveryFrame
        minViewport = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        DestroyOnOffScreen();

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
            Destroy(gameObject);
            gameManager.activePlayer.lives--;

            gameManager.CheckDeath();

            //Ignore the respawn process if the game is over
            if (gameManager.gameOver)
            {
                return;
            }


            gameManager.activePlayer.RespawnBall();
        }
    }
}
