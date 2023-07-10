using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CatStory
{
    public class FishSpawner : MonoBehaviour
    {
        [SerializeField]
        private float _fishSpeed;
        [SerializeField]
        private Rigidbody2D _fishRB;
        [SerializeField]
        private GameObject _fish;

        private SpriteRenderer _fishSprite;


        private float yPos;

        [SerializeField]
        private float amplitude = 3f;
        [SerializeField]
        private float timeDelay;


        private void Awake()
        {
            _fishSprite = GetComponent<SpriteRenderer>();
        }



        private void Start()
        {
            yPos = transform.position.y;
        }

        void Update()
        {
            _fish.transform.position = new Vector2(transform.position.x,
                    yPos + Mathf.Sin(Time.time * _fishSpeed) * amplitude);

            if (_fish.transform.position.y >= 2)
            {
                _fishSprite.flipY = true;
            }

        }



    }
}
