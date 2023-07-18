using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatStory
{
    public class BeetlePoint : MonoBehaviour
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
                _player._pickup4 = true;
                _inventory._pickup4beetle.sprite = _inventory._revealedPickup4;
                FindObjectOfType<BeetleManager>().AddBeetle();
                FindObjectOfType<BeetleManager>().ShowPickup1HUD();
                _pickupSound.Play();

                Destroy(gameObject);
            }



        }
    }
}
