using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatStory
{
    public class Enemy_Bat : Enemy_Class
    {


        [SerializeField]
        private GameObject _batDetector;

        [Header("Bat")]
        [SerializeField]
        private GameObject _bat;

        public Animator _batAnim;

        [SerializeField]
        private SpriteRenderer _batSprite;

        [SerializeField]
        private Collider2D _batCol;

        public GameObject _batStartPosition;

        [SerializeField]
        private PowerMeowSoundWave _powerMeow;

        public float _batSpeed = 3f;

               


        private void Awake()
        {
            _powerMeow = GetComponent<PowerMeowSoundWave>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public override void Update()
        {


            if (enemyLives == 0)

            {
                StartCoroutine(Dying());
            }


        }

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);   

            if(enemyLives > 0 && !isDead)
            {
                DamageEnemy();
            }


        }

        public void SetFacing()
        {
            if (_player.transform.position.x < _bat.transform.position.x)
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
            isDead = true;
            _batAnim.SetTrigger("idle");
            yield return new WaitForSeconds(0.5f);
            _bat.transform.position -= new Vector3(0f, _batSpeed * 5f * Time.deltaTime, 0f);
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
            Debug.Log("Dying");
            
        }
    }
}

