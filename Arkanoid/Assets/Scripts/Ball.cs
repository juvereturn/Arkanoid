using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed = 200f;

    private Rigidbody2D rb;
    private bool ballInPlay = false;

    public PlayerController player;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
       // Debug.Log("velocity " + rb.velocity);
        if (Input.GetKeyDown(KeyCode.Space) && ballInPlay == false) {
            transform.parent = null;
            ballInPlay = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(new Vector2(speed, speed));
        }
	}

    
}
