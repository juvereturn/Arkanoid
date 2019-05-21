using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 5f;

    private float input;

    public Ball ball;

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

    //Respawn at ballSpawnerPosition and make it a child of player
    public void RespawnBall() {
        Instantiate(ball, ballSpawnerPosition.transform.transform.position, Quaternion.identity, this.transform);
    }

    //Calculate ball movement according to where it hits the player
    public void PlayerBallCollision(Ball ball, Vector3 hitPoint)
    {
        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
        Vector3 paddleCenter = new Vector3(this.transform.position.x, this.transform.position.y);

        ballRb.velocity = Vector3.zero;

        float difference = paddleCenter.x - hitPoint.x;

        if (hitPoint.x < paddleCenter.x)
        {
            ballRb.AddForce(new Vector2(-(Mathf.Abs(difference * ball.speed)), ball.speed));
        }
        else {
            ballRb.AddForce(new Vector2((Mathf.Abs(difference * ball.speed)), ball.speed));
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            PlayerBallCollision(collision.gameObject.GetComponent<Ball>(), collision.contacts[0].point);
        }
    }
}
