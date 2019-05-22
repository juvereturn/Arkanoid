using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy the gameObject and add score if it collides with a ball
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            gameManager.AddScore(10);

            //remove a brick from bricks storage in order to check whether the game is over
            if (gameManager.brickList.Contains(this))
            {
                gameManager.brickList.Remove(this);
            }

            Destroy(this.gameObject);
        }
    }
}
