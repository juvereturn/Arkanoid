using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour {
    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Calculate ball movement according to where it hits the the border
    public void PlayerBallCollision(Ball ball, Vector3 hitPoint)
    {
        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
        Vector2 wallCenter = new Vector2(this.transform.position.x, this.transform.position.y);

        ballRb.velocity = Vector2.zero;

        float difference = wallCenter.y - hitPoint.y;

        if (hitPoint.y < wallCenter.y)
        {
            ballRb.AddForce(new Vector2(-(Mathf.Abs(difference * ball.speed)), ball.speed));
        }
        else
        {
            ballRb.AddForce(new Vector2((Mathf.Abs(difference * ball.speed)), ball.speed));
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.GetComponent<Ball>() != null) {

        }
    }
}
