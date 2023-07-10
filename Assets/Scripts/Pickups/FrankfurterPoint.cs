using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatStory
{
    public class FrankfurterPoint : MonoBehaviour
    {

        private PlayerController _player;

        [SerializeField]
        private InventoryController _inventory;

        [SerializeField]
        private AudioSource _pickupSound;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerController>(); 
            
        }
                

        public void OnTriggerEnter2D(Collider2D collision)
        {
            
            if(collision.GetComponent<PlayerController>() && _player != null) 
            {
                Debug.Log(_player);
                Debug.Log(_inventory);
                _player._pickup1 = true;               
                _inventory._pickup1Frankfurter.sprite = _inventory._revealedPickup1;
                _pickupSound.Play();

                FindObjectOfType<FrankfurterManager>().AddFrankfurter();
                FindObjectOfType<FrankfurterManager>().ShowPickup1HUD();

                Destroy(gameObject);
            }
            
            
            
        }


    }
}
