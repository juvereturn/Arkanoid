using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrueAxion.Arkanoid
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Ball))]
    public class BallBouncingCalculator : MonoBehaviour
    {

        //Add force to the ball according to where it hits the player
        public void CalculateBallBouncing(Vector3 hitPoint, Vector2 bouncingObjCenter)
        {
            Rigidbody2D ballRb = GetComponent<Rigidbody2D>();
            Ball ball = GetComponent<Ball>();

            //set velocity to (0, 0) to avoid miscalculation
            ballRb.velocity = Vector2.zero;

            //find the difference between center of bouncing object and hit point
            float difference = bouncingObjCenter.x - hitPoint.x;

            //Add force to the ball using the differnce * ball speed
            if (hitPoint.x < bouncingObjCenter.x)
            {
                ballRb.AddForce(new Vector2(-(Mathf.Abs(difference * ball.speed)), ball.speed));
            }
            else
            {
                ballRb.AddForce(new Vector2((Mathf.Abs(difference * ball.speed)), ball.speed));
            }
        }
    }
}