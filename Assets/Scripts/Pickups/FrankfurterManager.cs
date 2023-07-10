using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

namespace CatStory
{
    public class FrankfurterManager : MonoBehaviour
    {
        private PlayerController _player;
        
        [SerializeField]
        private InventoryController _inventory;

        [SerializeField]
        private UIController _HUD;

        [SerializeField]
        private GameObject _pickup1_Panel;

        private LifeManager _lifeManager;

        private float _coroutineTime = 0.5f;
        private float _lifeTextTime = 0.5f;

        public int Frankfurters;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerController>();
            _lifeManager = FindObjectOfType<LifeManager>();
        }

        private void Update()
        {
            SetPickupAbility();
            ShowPickupAbilityPanel();
        }

        public void AddFrankfurter()
        {
            Frankfurters += 1;
            StartCoroutine(ShowPopUpText());

        }

        private void SetPickupAbility()
        {
            if (Frankfurters >= 5)
            {
                _player._frankAbilityIsReady = true;
                
            }

            if (Frankfurters <= 4)
            {
                _player._frankAbilityIsReady = false;
                
            }
        }

        private void ShowPickupAbilityPanel()
        {
            if (Frankfurters == 5)
            {
                StartCoroutine(ShowPickup1AbilityPanel());
                _inventory._pickup1Frankfurter.sprite = _inventory._activeFrankAbility;
            }
        }

        public void TurnFrankfurterAbility()
        {
                       
            if (Frankfurters >= 5) 
            {
                Frankfurters -= 5;
                _lifeManager.Lives += 1;
                _inventory.UpdatePickupText();
                StartCoroutine(ShowLifeText());
                HidePickup1AbilityPanel();


            }
            else
            {
                return;
            }
        }

        public void ShowPickup1HUD()
        {
            StartCoroutine(ShowPickupHUD());

        }

        //---UI Pickup Coroutine---

        private IEnumerator ShowPickupHUD()
        {
            while (true)
            {
                _pickup1_Panel.SetActive(true);
                _inventory.UpdatePickupText();
                yield return new WaitForSeconds(4f);
                _pickup1_Panel.SetActive(false);
                yield break;
            }
        }

        private IEnumerator ShowPopUpText()
        {
            
            while (true)
            {
                _HUD._Pop_up_frankfurterText.enabled = true;
                yield return new WaitForSeconds(3f);                              
                _HUD._Pop_up_frankfurterText.enabled = false;
                
                yield break;
            }
            
        }

        private IEnumerator ShowPickup1AbilityPanel()
        {
            var time = _coroutineTime;
            while (time > 0)
            {
                _HUD._frankfurterPanel.enabled = true;
                yield return new WaitForSeconds(_coroutineTime);
                _HUD._frankfurterPanel.enabled=false;
                _HUD._frankAbilityText.enabled = true;

            }
        }

        private IEnumerator ShowLifeText()
        {
            var time = _lifeTextTime;
                while (time > 0)
            {
                _HUD._Pop_up_lifeText.enabled = true;
                yield return new WaitForSeconds(_lifeTextTime);
                _HUD._Pop_up_lifeText.enabled = false;
            }
        } 

        private void HidePickup1AbilityPanel()
        {

            _HUD._frankAbilityPic.SetActive(false);
            _inventory._pickup1Frankfurter.sprite = _inventory._revealedPickup1;
            _HUD._frankAbilityText.enabled = false;
        }


    }
}
