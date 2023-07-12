using CatStory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

namespace CatStory
{

    public abstract class Enemy_Class : MonoBehaviour
    {
        public PlayerController _player;

        public GameObject _playerGO;

        public SpriteRenderer _playerSprite;

        public SpriteRenderer _enemySprite;
                                       
        public float _damagePlayerTime = 0.025f;

        public float _damageEnemyTime = 0.025f;
                
        public float rayDistance;

        //-----------Properties----------
        private bool isFacingRight;

        public bool IsFacingRight { get { return isFacingRight; } set { isFacingRight = value; } }

        private bool isAttacking;

        public bool IsAttacking { get { return isAttacking; } set { isAttacking = value; } }
        //---------------

        public int enemyLives;

        public bool isDead = false;

        public bool isPlayerInvulnerable;


        private void Start()
        {
            Physics2D.queriesStartInColliders = false;
            _player = FindObjectOfType<PlayerController>();
        }

        public virtual void Update()
        {
            {             
            
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.right, rayDistance);
                            
                RaycastHit2D lefthit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.left, rayDistance);
                
            }
                         

        }


        private void OnDrawGizmos()
        {
            
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * rayDistance);
            
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.left * rayDistance);
            
            
        }



        public virtual void OnTriggerEnter2D(Collider2D collision) // damage when colliding
        {
            //if (collision.GetComponent<PlayerController>() && !isPlayerInvulnerable && !_player.isDead)
            //{
            //    FindObjectOfType<LifeManager>().LoseLives();

            //    StartCoroutine(DamagePlayer());

            //    StartCoroutine(StopBlinkingPlayerSprite());
            //}

            if (collision.GetComponent<PowerMeowSoundWave>() != null) //damage if shot with PowerMeow
            {
                
                if (enemyLives > 0)
                {
                    enemyLives -= 1;
                    StartCoroutine(DamageEnemy());

                    Debug.Log("Enemy is hit");
                    Debug.Log(isAttacking);
                    Debug.Log(isFacingRight);
                }
                
                
                if (enemyLives == 0)
                {
                    Debug.Log("Enemy is dead");
                    Debug.Log(isAttacking);
                    Debug.Log(isFacingRight);
                    
                }
                
            }

            if (collision.GetComponent<PawHitBox>())
            {
                if (enemyLives > 0)
                {
                    enemyLives -= 1;
                    StartCoroutine(DamageEnemy());

                    Debug.Log("Enemy is hit");
                    Debug.Log(isAttacking);
                    Debug.Log(isFacingRight);
                }


                if (enemyLives == 0)
                {
                    Debug.Log("Enemy is dead");
                    Debug.Log(isAttacking);
                    Debug.Log(isFacingRight);

                }
            }

        }


        public IEnumerator DamagePlayer()
        {

            var time = _damagePlayerTime;
            while (time > 0 && !_player.isDead)
            {
                StartCoroutine(SetPlayerInvulnerability());
                _playerSprite.enabled = !_playerSprite.enabled;
                _playerSprite.color = new Color32(0xBC, 0x3A, 0x3A, 0xFF);
                time -= Time.deltaTime;
                yield return new WaitForSeconds(0.1f);
            }
            _playerSprite.color = Color.white;
            _playerSprite.enabled = true;

        }

        public IEnumerator DamageEnemy()
        {

            var time = _damageEnemyTime;
            while (time > 0)
            {
                _enemySprite.enabled = !_enemySprite.enabled;
                _enemySprite.color = new Color32(0xBC, 0x3A, 0x3A, 0xFF);
                time -= Time.deltaTime;
                yield return new WaitForSeconds(0.1f);
            }
            _enemySprite.color = Color.white;
            _enemySprite.enabled = true;

        }




        //public IEnumerator StopBlinkingPlayerSprite()
        //{
        //    yield return new WaitForSeconds(0.025f);
        //    StopCoroutine(DamagePlayer());
        //}

           

        public void HighlightSprite() 
        {
            _enemySprite = GetComponent<SpriteRenderer>();

            Material mat = new Material(_enemySprite.material.shader);
            mat.SetColor("_OutlineColor", Color.blue);
            mat.SetFloat("_OutlineWidth", 0.02f);
            mat.SetFloat("_OutlineNormalThreshold", 0.5f);
            mat.SetFloat("_Outline", 1.0f);


        }

        public IEnumerator SetPlayerInvulnerability(float invTime = 5f)
        {
            isPlayerInvulnerable = true;
            yield return new WaitForSeconds(invTime);
            isPlayerInvulnerable = false;
        }

    }
}
