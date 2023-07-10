using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CatStory
{
    public class FallingDownGameOver : MonoBehaviour
    {

        private GameManager _gameManager;

        [SerializeField]
        private PlayerController _player;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>() && _gameManager != null)
            {
                _gameManager._gameOverScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }




    }
}
