using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace CatStory
{
    public class CavernEntranceMarker : MonoBehaviour
    {
        [SerializeField]
        private PlayerController _player;

        [SerializeField]
        private GameManager _gameManager;

        private void Awake()
        {
            _player= FindObjectOfType<PlayerController>();
            _gameManager = FindObjectOfType<GameManager>();
        }

        public bool enteredCavern = false;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.GetComponent<PlayerController>() && _player != null && !enteredCavern)
            {
                enteredCavern = true;
                _gameManager.StopCameraY();
            }

            else if (enteredCavern)
            {
                _gameManager.ReturnCameraY();
                enteredCavern = false;
            }

        }
    }
}

