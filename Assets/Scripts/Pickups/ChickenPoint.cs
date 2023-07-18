using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatStory
{
    public class ChickenPoint : MonoBehaviour
    {
        private PlayerController _player;

        [SerializeField]
        private InventoryController _inventory;

        [SerializeField]
        private AudioSource _pickupSound;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerController>();
            //_inventory = FindObjectOfType<InventoryController>();
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.GetComponent<PlayerController>() && _player != null)
            {

                Debug.Log(_player);
                Debug.Log(_inventory);
                _player._pickup2 = true;
                _inventory._pickup2Chicken.sprite = _inventory._revealedPickup2;
                FindObjectOfType<ChickenManager>().AddChickenLegs();
                FindObjectOfType<ChickenManager>().ShowPickup1HUD();
                _pickupSound.Play();

                Destroy(gameObject);
            }



        }
    }
}
