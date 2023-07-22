using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CatStory
{

    public class Enemy_Hedgehog : Enemy_Class
    {

        [SerializeField]
        public Animator _hedgehogAnim;

        [SerializeField]
        private GameObject _hedgehog;

        [SerializeField]
        private SpriteRenderer _hedgeSprite;

        [SerializeField]
        private float _hedgeSpeed;
        [SerializeField]
        private float _hedgeAttackSpeed;

        [SerializeField]
        private float _amplitude;

        [SerializeField]
        private CapsuleCollider2D _hedgehogCol;

        [SerializeField]
        private Rigidbody2D _hedgehogRB;

        private PowerMeowSoundWave _powerMeow;
 

        [SerializeField]
        private Transform[] _destPoints; // point of destinations
        private int _randomDestPoint;// random point of destination

        private float _waitTime;
        public float _startWaitTime;

        public float xPosLeftLimit;
        public float xPosRightLimit;


       

        private void Awake()
        {
            _powerMeow = GetComponent<PowerMeowSoundWave>();
        }

        void Start()
        {
            
            _waitTime = _startWaitTime;
            _randomDestPoint = Random.Range(0, _destPoints.Length);

            xPosLeftLimit = _hedgehog.transform.position.x - _amplitude;
            xPosRightLimit = _hedgehog.transform.position.x + _amplitude;

        }
                     

        public override void Update()
        {
            base.Update();

            SetFacing();

            if (enemyLives == 0 && IsFacingRight || enemyLives == 0 && !IsFacingRight)
            {
                transform.position = transform.position;
                StartCoroutine(Dying());
                
            }
            else
            {
                if (!IsAttacking) _hedgehog.transform.position = 
                    Vector2.MoveTowards(transform.position, _destPoints[_randomDestPoint].position,
                    _hedgeSpeed * Time.deltaTime);//patrolling

                if (IsAttacking) //attacking
                {
                    Vector3 direction = _player.transform.position - _hedgehog.transform.position;
                    direction.Normalize();
                    _hedgehogAnim.SetTrigger("attack");

                    _hedgehog.transform.position += 
                       direction * _hedgeAttackSpeed * Time.deltaTime;

                }


                if (Vector2.Distance(_hedgehog.transform.position, _destPoints[_randomDestPoint].position) < 0.2f)
                {
                    if (_waitTime <= 0)
                    {
                        _randomDestPoint = Random.Range(0, _destPoints.Length);
                        _waitTime = _startWaitTime;
                    }
                    else
                    {
                        _waitTime -= Time.deltaTime;
                    }

                    foreach (Transform _randomDestPoint in _destPoints)
                    {

                        if (_randomDestPoint.position.x > _hedgehog.transform.position.x)
                        {
                            _hedgehog.transform.localScale = new Vector2(0.79f, 0.79f);
                        }
                        if (_randomDestPoint.position.x < _hedgehog.transform.position.x)
                        {
                            _hedgehog.transform.localScale = new Vector2(-0.79f, 0.79f);
                        }
                    }
                }

               




            }
        }

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);

            if (collision.GetComponent<PlayerController>() && !_player.isDead && !_player.isInvulnerable) 
            {
                if (!_player._isSuperCat)
                {
                    FindObjectOfType<LifeManager>().Lives -= 1;

                }
            }
        } 

        public void SetFacing()
        {
            if (_player.transform.position.x < _hedgehog.transform.position.x)
            {
                IsFacingRight = false;

            }
            else
            {
                IsFacingRight = true;
            }
        }

        private IEnumerator Dying()
        {
            IsAttacking = false;
            _hedgehogAnim.SetTrigger("dead");
            yield return new WaitForSeconds(1f);
            _hedgeSprite.enabled = !_hedgeSprite.enabled;
            _hedgeSprite.color = Color.red;
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }


    }


    

}
