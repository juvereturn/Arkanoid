using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrueAxion.Arkanoid
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance { get; private set; }

        [Tooltip("initial life of the players")]
        [SerializeField]private int lives = 3;

        public int GetCurrentLife() { return lives; }

        [Tooltip("movement speed of the players")]
        [SerializeField] private float speed = 5f;

        //store the input direction from -1, 0, 1
        private float input;

        [Tooltip("Store the ball prefab")]
        public Ball ball;

        [Tooltip("Store where the ball will be spawned")]
        public GameObject ballSpawnerPosition;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        void Update()
        {
            //Get the axis range from -1, 0, 1
            input = Input.GetAxisRaw("Horizontal");
        }

        private void FixedUpdate()
        {
            //Move the player character only in horizontal direction
            GetComponent<Rigidbody2D>().velocity = input * Vector2.right * speed;
        }

        /// <summary>
        /// Decrease player's lives by 1 in default.
        /// </summary>
        public void DecreaseALife()
        {
            lives--;
        }

        //Respawn at ballSpawnerPosition and make it a child of player
        public void RespawnBall()
        {
            Instantiate(ball, ballSpawnerPosition.transform.position, Quaternion.identity, this.transform);
        }
    }
}