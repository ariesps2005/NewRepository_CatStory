
using System.Collections;
using UnityEngine;


namespace CatStory
{
    public class Enemy_Snake : Enemy_Class
    {
                        
        [Header("Snake")]
        [SerializeField]
        private Rigidbody2D _snakeRB;

        [SerializeField]
        public Animator _snakeAnim;

        [SerializeField]
        private Collider2D _snakeCol;

        [SerializeField]
        private SpriteRenderer _snakeSprite;

        [Header("Snake Spit")]
        [SerializeField]
        private Transform _spitFirepoint;
        [SerializeField]
        private GameObject _spitPrefab;

        public float _spitSpeed = 10f;

        public float _spitLifetime = 0.5f;

        public float _spitTimer;

       

        private void Awake()
        {
            IsFacingRight = false;
            IsAttacking = false;
        }

        public override void Update()
        {
            base.Update();

            SetFacing();

            if (enemyLives == 0)
            {
                StartCoroutine(Dying());
            }

            if (IsAttacking && IsFacingRight)
            {
                _spitTimer += Time.deltaTime;

                if (_spitTimer > 2)
                {
                    _spitTimer = 0;
                    Spit();
                }
            }

            if (IsAttacking && !IsFacingRight)
            {
                _spitTimer += Time.deltaTime;

                if (_spitTimer > 2)
                {
                    _spitTimer = 0;
                    Spit();
                }
            }





            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.right, rayDistance);
            if (hit.collider != null && IsFacingRight)
            {
                IsFacingRight = true;
                _snakeSprite.flipX = true;
                IsAttacking = true;
                _snakeAnim.SetTrigger("attack");
               


            }
            else if (IsFacingRight)
            {
                IsAttacking = false;
                IsFacingRight = true;
                _snakeSprite.flipX = true;
                _snakeAnim.SetTrigger("idle");

            }
            else if(enemyLives <= 0)
            {
                _snakeAnim.SetTrigger("dead");
            }

            RaycastHit2D lefthit = Physics2D.Raycast(transform.position, transform.localScale.x 
                * Vector2.left, rayDistance);
            if (lefthit.collider != null && !IsFacingRight)
            {
                IsFacingRight = false;
                _snakeSprite.flipX = false;
                IsAttacking = true;
                _snakeAnim.SetTrigger("attack");
               

            }
            else if(!IsFacingRight)
            {
                IsAttacking = false;
                IsFacingRight = false;
                _snakeSprite.flipX = false;
                _snakeAnim.SetTrigger("idle");

            }
            else if (enemyLives <= 0)
            {
                _snakeAnim.SetTrigger("dead");
            }

        }


        public void SetFacing()
        {
            if (_player.transform.position.x < this.transform.position.x)
            {
                IsFacingRight = false;
                
            }
            else
            {
                IsFacingRight = true;
            }
        }

        private void Spit()
        {
            Instantiate(_spitPrefab, _spitFirepoint.position, Quaternion.identity);
        }

        private IEnumerator Dying()
        {
            IsAttacking = false;
            _snakeAnim.SetTrigger("dead");
            yield return new WaitForSeconds(1f);
            _snakeSprite.enabled = !_snakeSprite.enabled;
            _snakeSprite.color = Color.red;
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}





