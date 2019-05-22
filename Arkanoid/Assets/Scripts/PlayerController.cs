using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Tooltip("initial life of the players")]
    public int lives = 3;

    [Tooltip("movement speed of the players")]
    public float speed = 5f;

    //store the input direction from -1, 0, 1
    private float input;

    [Tooltip("Store the ball prefab")]
    public Ball ball;

    [Tooltip("Store where the ball will be spawned")]
    public GameObject ballSpawnerPosition;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //Get the axis range from -1, 0, 1
        input = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() {
        //Move the player character only in horizontal direction
        GetComponent<Rigidbody2D>().velocity = input * Vector2.right * speed;
    }

    public void DecreaseALife() {
        lives--;
    }

    //Respawn at ballSpawnerPosition and make it a child of player
    public void RespawnBall() {
        Instantiate(ball, ballSpawnerPosition.transform.transform.position, Quaternion.identity, this.transform);
    }

    //Add force to the ball according to where it hits the player
    public void PlayerBallCollision(Ball ball, Vector3 hitPoint)
    {
        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();

        //Get the player's center
        Vector2 playerCenter = new Vector2(this.transform.position.x, this.transform.position.y);

        //set velocity to (0, 0) to avoid miscalculation
        ballRb.velocity = Vector2.zero;

        //find the difference between center of player and hit point
        float difference = playerCenter.x - hitPoint.x;

        //Add force to the ball using the differnce * ball speed
        if (hitPoint.x < playerCenter.x)
        {
            ballRb.AddForce(new Vector2(-(Mathf.Abs(difference * ball.speed)), ball.speed));
        }
        else {
            ballRb.AddForce(new Vector2((Mathf.Abs(difference * ball.speed)), ball.speed));
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Call PlayerBall Collision if it hits a ball
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            PlayerBallCollision(collision.gameObject.GetComponent<Ball>(), collision.contacts[0].point);
        }
    }
}
