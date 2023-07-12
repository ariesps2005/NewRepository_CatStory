using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatStory
{
    public class Enemy_Frog : Enemy_Class
    {

        [SerializeField]
        public Animator _frogAnim;

        [Header("Frog")]
        [SerializeField]
        private Collider2D _frogCol;

        [SerializeField]
        public SpriteRenderer _frogSprite;

        [SerializeField]
        private GameObject _frog;

        [SerializeField]
        private PowerMeowSoundWave _powerMeow;

        [SerializeField]
        public Rigidbody2D _frogRB;

       
        public float frogSpeed;

        public float jumpDistance;

        public float jumpForce;


        private void Awake()
        {
            _powerMeow = GetComponent<PowerMeowSoundWave>();
        }

        public override void Update()
        {
            base.Update();


            
            SetFacing();
            
            if (enemyLives == 0)

            {
                StartCoroutine(Dying());
            }
        }



        


        public void SetFacing()
        {
            if (_player.transform.position.x < _frog.transform.position.x)
            {
                IsFacingRight = false;
                _frogSprite.flipX = false;

            }
            else
            {
                IsFacingRight = true;
                _frogSprite.flipX = true;
            }
        }




        private IEnumerator Dying()
        {
            isDead = true;
            _frogAnim.SetTrigger("dead");
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
            Debug.Log("Dying");

        }

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);

            if (collision.GetComponent<PlayerController>() && !isPlayerInvulnerable && !_player.isDead)
            {
                _frogAnim.SetTrigger("dead");
                Destroy(gameObject, 0.5f);
                FindObjectOfType<LifeManager>().Lives -= 2;

                StartCoroutine(DamagePlayer());
            }

            if (collision.GetComponent<PowerMeowSoundWave>() && _powerMeow != null && !isPlayerInvulnerable && !_player.isDead)
            {

                Debug.Log("PowerMeow Shot");
                if (enemyLives > 0)
                {
                    enemyLives -= 1;
                    StartCoroutine(DamageEnemy());

                    Debug.Log("Enemy is hit");
                    
                }


                if (enemyLives == 0)
                {
                    Debug.Log("Enemy is dead");
                    

                }
            }
        }


    }

}

