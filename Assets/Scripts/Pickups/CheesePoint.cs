using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatStory
{
    public class CheesePoint : MonoBehaviour
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
                _player._pickup3 = true;
                _inventory._pickup3Cheese.sprite = _inventory._revealedPickup3;
                FindObjectOfType<CheeseManager>().AddCheese();
                FindObjectOfType<CheeseManager>().ShowPickup1HUD();
                _pickupSound.Play();

                Destroy(gameObject);
            }



        }
    }
}
