using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CatStory
{
    public class TouchingDirections : MonoBehaviour
    {

        public ContactFilter2D castFilter;
        private Rigidbody2D _playerRB;

        private Animator animator;


        RaycastHit2D[] groundHits = new RaycastHit2D[2];
        public float groundDistance = 0.05f;

        RaycastHit2D[] ceilingHits = new RaycastHit2D[2];
        public float ceilingDistance = 0.02f;

        private Collider2D touchingCol;

        [SerializeField]
        private bool _isGrounded = true;

        [SerializeField]
        private bool _isOnTheCeiling = true;

        private void Awake()
        {
            touchingCol = GetComponent<Collider2D>();
            animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            IsGrounded = touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
            _isOnTheCeiling = touchingCol.Cast(Vector2.up, castFilter, ceilingHits, ceilingDistance) > 0;
        }

        public bool IsGrounded
        {
            get { return _isGrounded; }

            private set
            {
                _isGrounded = value;
                animator.SetBool(AnimationStrings.isGrounded, value);
            }
        }

        public bool IsOnTheCeiling { get { return _isOnTheCeiling;}
        private set
            {
                _isOnTheCeiling = value;
                animator.SetBool(AnimationStrings.isOnTheCeiling, value);
            }
        }

    }
}
