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
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            gameManager.AddScore(10);

            if (gameManager.brickSpawner.bricks.Contains(this))
            {
                gameManager.brickSpawner.bricks.Remove(this);
            }

            Destroy(this.gameObject);
        }
    }
}
