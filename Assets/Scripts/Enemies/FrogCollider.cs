using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatStory
{
    public class FrogCollider : MonoBehaviour
    {
        private PlayerController _player;

        [SerializeField]
        private Enemy_Frog _frog;

        private Vector3 originalPos;
       
        void Start()
        {
            _player = FindObjectOfType<PlayerController>();
            originalPos = _frog.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            this.GetComponent<Rigidbody2D>().WakeUp();

            //Vector3 direction = (_player.transform.position - _frog.transform.position).normalized;
            //Vector3 target = _frog.transform.position + direction * _frog.jumpDistance;


            Vector3 target = _frog.transform.position + new Vector3(-2f, 2f, 0f);

            if (_frog.IsAttacking)
            {
                FrogJump();
            }
        }
             

        private void OnTriggerStay2D(Collider2D collider)
        {
            if (collider.CompareTag("Player") && _player != null)
            {
                

                _frog._frogAnim.SetTrigger("attack");
                _frog.IsAttacking = true;
                
                
                Debug.Log("attack");
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.GetComponent<PlayerController>() && _player != null)
            {
                _frog._frogAnim.SetTrigger("idle");
                _frog.IsAttacking = false;
                Debug.Log("idle");
            }
        }

        private void FrogJump()
        {
            //Vector3 direction = (target - _frog.transform.position).normalized;
            //_frog._frogRB.velocity = direction * _frog.frogSpeed * _frog.jumpDistance * Time.deltaTime; 
            
            
            if (!_frog.IsFacingRight)
            {
                _frog._frogRB.velocity = new Vector2(-1f * _frog.frogSpeed, _frog._frogRB.velocity.y);
                _frog._frogRB.AddForce(Vector2.up * _frog.jumpForce, ForceMode2D.Impulse);

                Debug.Log("frog jumps to the left");
            }
            else
            {
                _frog._frogRB.velocity = new Vector2(1f * _frog.frogSpeed, _frog._frogRB.velocity.y);
                _frog._frogRB.AddForce(Vector2.up * _frog.jumpForce, ForceMode2D.Impulse);

                Debug.Log("frog jumps to the right");
            }
           
        }

        private void FrogStop()
        {
            _frog._frogRB.velocity = new Vector2(1f * _frog.frogSpeed, _frog._frogRB.velocity.y);
        }

        
    }

}
