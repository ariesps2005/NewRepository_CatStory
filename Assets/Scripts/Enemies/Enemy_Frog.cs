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

        //[SerializeField]
        //private AudioSource _frogSound;
       
        public float frogSpeed;

        public float jumpDistance;

        public float jumpForce;


        private void Awake()
        {
            _powerMeow = GetComponent<PowerMeowSoundWave>();
            //_frogSound = GetComponent<AudioSource>();
            
        }

        private void Start()
        {
            //_frogSound.Play();
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

                if (!_player._isSuperCat)
                {
                    FindObjectOfType<LifeManager>().Lives -= 3;

                }
                if (_player._isSuperCat)
                {
                    FindObjectOfType<LifeManager>().Lives -= 1;
                }
                

                StartCoroutine(DamagePlayer());
            }

            if (collision.GetComponent<PowerMeowSoundWave>() && _powerMeow != null && !isPlayerInvulnerable && !_player.isDead)
            {

                if (!_player._isSuperCat)
                {
                    Debug.Log("PowerMeow Shot");

                    if (enemyLives > 0)
                    {

                        StartCoroutine(DamageEnemy());

                        Debug.Log("Enemy is hit");

                    }

                    if (enemyLives == 0)
                    {
                        Debug.Log("Enemy is dead");


                    }
                }

                if (_player._isSuperCat)
                {
                    Debug.Log("PowerMeow Shot");

                    if (enemyLives > 0)
                    {

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

}

