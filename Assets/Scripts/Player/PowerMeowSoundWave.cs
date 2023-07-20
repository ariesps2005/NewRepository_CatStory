using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatStory
{
    public class PowerMeowSoundWave : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _powerMeowSoundWave;

        [SerializeField]
        private SpriteRenderer _sprite;

        [SerializeField]
        private Transform _powerMeowSound;

        [SerializeField]
        private float _soundWaveSpeed;

        [SerializeField]
        private PlayerController _player;

        [SerializeField]
        private Transform _meowFirePoint;

        public Transform MeowFirePoint => _meowFirePoint;

        private void Start()
        {
            _player = FindObjectOfType<PlayerController>();


        }


        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_player._isSuperCat)
                Destroy(gameObject);

            if (_player._isSuperCat)
                Destroy(gameObject);
        }



        void Update()
        {
            

            if (_player._isFacingRight)
            {

                _powerMeowSoundWave.velocity = transform.right * _soundWaveSpeed * Time.deltaTime;

                Destroy(gameObject, 2f);


            }


            if (!_player._isFacingRight)
            {
                transform.localScale = new Vector2(-0.57f, 0.57f);
                _powerMeowSoundWave.velocity = -transform.right * _soundWaveSpeed * Time.deltaTime;
                Destroy(gameObject, 2f);
            }
        }


    
        
    }
}
