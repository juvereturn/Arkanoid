using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrueAxion.Arkanoid
{

    public class Brick : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosionParticle;

        void Start()
        {
            GameManager.Instance.brickList.Add(this);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            //Destroy the gameObject and add score if it collides with a ball
            if (collision.gameObject.GetComponent<Ball>() != null)
            {
                GameManager.Instance.AddScore(10);

                //remove a brick from bricks storage in order to check whether the game is over
                GameManager.Instance.DestroyABrick(this);

                SpawnExplosionParticle();

                Destroy(this.gameObject);
            }
        }

        private void SpawnExplosionParticle() {
            if (explosionParticle)
            {
                explosionParticle.startColor = this.GetComponent<SpriteRenderer>().color;
                Instantiate(explosionParticle, this.transform.position, Quaternion.identity);
            }
        }
    }

}
