using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatStory
{
    public class BatCollider : MonoBehaviour
    {

        private PlayerController _player;

        [SerializeField]
        private Enemy_Bat _bat;

        
               

        private void Awake()
        {
            _player = FindObjectOfType<PlayerController>();

        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>() && _player != null && !_bat.isDead)
            {
                _bat._batAnim.SetTrigger("attack");
                Vector3 direction = _player.transform.position - _bat.transform.position;
                direction.Normalize();

                _bat.transform.position +=
                   direction * _bat._batSpeed * Time.deltaTime;

                
            }
          
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!_bat.isDead) 
            {
                _bat._batAnim.SetTrigger("idle");


                // Doesn't work. Ask Alexey about it...

                //Vector3 direction = _bat._batStartPosition.transform.position - _bat.transform.position;
                //direction.Normalize();

                //_bat.transform.position -= direction * _bat._batSpeed * Time.deltaTime;

                //if (_bat.transform.position == _bat._batStartPosition.transform.position)
                //{
                //    _bat._batAnim.SetTrigger("idle");
                //}

                _bat.transform.position = _bat._batStartPosition.transform.position;
            }

           

            
            
        }

    }

}
