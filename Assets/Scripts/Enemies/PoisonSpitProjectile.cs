using System.Collections;
using TMPro;
using UnityEngine;


namespace CatStory
{
    public class PoisonSpitProjectile : MonoBehaviour
    {
        private GameObject _player;
               
        [SerializeField]
        private Rigidbody2D _spitRB;

        private Enemy_Snake _snake;
        

        public float Force;

        private void Awake()
        {
            _snake = FindObjectOfType<Enemy_Snake>();
            
        }

        // Start is called before the first frame update
        private void Start()
        {
            

            _spitRB = GetComponent<Rigidbody2D>();
            _player = GameObject.FindGameObjectWithTag("Player");

            if (_player.transform.position.x < _snake.transform.position.x)//player is left to snake
            {
                Vector3 direction = _player.transform.position - transform.position;
                _spitRB.velocity = new Vector2(direction.x, direction.y).normalized * Force;
            }

            if (_player.transform.position.x > _snake.transform.position.x)//player is right to snake
            {
                Vector3 direction = _player.transform.position - transform.position;
                _spitRB.velocity = new Vector2(-direction.x, direction.y).normalized * Force;
            }

        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(gameObject);
        }

        


    }

}
