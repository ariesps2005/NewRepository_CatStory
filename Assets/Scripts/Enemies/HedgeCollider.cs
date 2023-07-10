using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CatStory 
{
    public class HedgeCollider : MonoBehaviour
    {

        private PlayerController _player;

        [SerializeField]
        private Enemy_Hedgehog hedgehog;
        // Start is called before the first frame update
        void Start()
        {
            _player= FindObjectOfType<PlayerController>();  
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>() && _player!= null)
            {
                hedgehog.IsAttacking = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>() && _player != null)
            {
                hedgehog._hedgehogAnim.SetTrigger("idle");
                hedgehog.IsAttacking = false;
            }
        }


    }
}


