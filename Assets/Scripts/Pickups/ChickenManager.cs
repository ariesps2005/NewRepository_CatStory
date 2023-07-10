using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatStory
{
    public class ChickenManager : MonoBehaviour
    {
        [SerializeField]
        private InventoryController _inventory;

        [SerializeField]
        private UIController _HUD;

        [SerializeField]
        private GameObject _pickup2_Panel;


        public int ChickenLegs;

        public void AddChickenLegs()
        {
            ChickenLegs++;
            StartCoroutine(ShowPopUpText());

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
                _pickup2_Panel.SetActive(true);
                _inventory.UpdatePickupText();
                yield return new WaitForSeconds(4f);
                _pickup2_Panel.SetActive(false);
                yield break;
            }
        }

        private IEnumerator ShowPopUpText()
        {
            var fadingTime = 2f;

            while (true)
            {
                _HUD._Pop_up_chickenText.enabled = true;
                yield return new WaitForSeconds(2f);
                _HUD._Pop_up_chickenText.color = Color.Lerp(new Color(0, 1, 0, 1), new Color(0, 1, 0, 0), fadingTime);
                yield return new WaitForSeconds(1f);
                _HUD._Pop_up_chickenText.enabled = false;
                _HUD._Pop_up_chickenText.color = Color.Lerp(new Color(0, 1, 0, 0), new Color(0, 1, 0, 1), fadingTime);

                yield break;
            }

        }
    }

}
