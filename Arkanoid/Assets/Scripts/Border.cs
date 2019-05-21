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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ball>() != null) {
            Destroy(collision.gameObject);
            FindObjectOfType<PlayerController>().RespawnBall();
        }
    }
}
