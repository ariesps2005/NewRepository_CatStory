using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

namespace CatStory
{

    public class LifeManager : MonoBehaviour
    {
        private PlayerController _player;

        [SerializeField]
        private GameManager _gameManager;

        public int Lives = 9;

        [SerializeField]
        private UIController _HUD;

        void Start()

        {
            _player = FindObjectOfType<PlayerController>();
            _gameManager = FindObjectOfType<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LoseLives()
        {
            if (Lives > 0 && !_player.isDead)
            {
                Lives -= 1;
            }


            if (Lives == 0 && _player.isDead)
            {
                Die();
                


            }

        }

        public void GetLife()
        {

            Lives += 1;
            StartCoroutine(ShowPopUpText());
        }

        public void Die()
        {
            _player.isDead = true;
            StartCoroutine(Dying());
            
        }

        //--------UI Pop-up Coroutine----------
        private IEnumerator ShowPopUpText()
        {
            var fadingTime = 2f;

            while (true)
            {



                _HUD._Pop_up_lifeText.enabled = true;
                yield return new WaitForSeconds(2f);
                _HUD._Pop_up_lifeText.color = Color.Lerp(new Color(0, 1, 0, 1), new Color(0, 1, 0, 0), fadingTime);
                yield return new WaitForSeconds(1f);
                _HUD._Pop_up_lifeText.enabled = false;
                _HUD._Pop_up_lifeText.color = Color.Lerp(new Color(0, 1, 0, 0), new Color(0, 1, 0, 1), fadingTime);

                yield break;
            }

        }

        private IEnumerator Dying()
        {
            while (true && _player.isDead)
            {
                Lives = 0;
                _player._playerAnim.SetTrigger(AnimationStrings.dead);
                yield return new WaitForSeconds(2f);
                _gameManager._gameOverScreen.SetActive(true);
                Time.timeScale = 0;
            }
            
        }
    }

    
    


}
