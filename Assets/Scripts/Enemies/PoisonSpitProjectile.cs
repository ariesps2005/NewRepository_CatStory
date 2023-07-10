using System.Collections;
using UnityEngine;


namespace CatStory
{
    public class PoisonSpitProjectile : MonoBehaviour
    {
        private GameObject _player;
               
        [SerializeField]
        private Rigidbody2D _spitRB;

        public float Force;

        private void Awake()
        {
            
            
        }

        // Start is called before the first frame update
        private void Start()
        {
            _spitRB = GetComponent<Rigidbody2D>();
            _player = GameObject.FindGameObjectWithTag("Player");

            Vector3 direction = _player.transform.position - transform.position;
            _spitRB.velocity = new Vector2(direction.x, direction.y).normalized * Force;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(gameObject);
        }

        


    }

}
