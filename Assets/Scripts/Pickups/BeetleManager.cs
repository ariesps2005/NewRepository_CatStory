using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatStory
{
    public class BeetleManager : MonoBehaviour
    {
        [SerializeField]
        private InventoryController _inventory;

        [SerializeField]
        private UIController _HUD;

        public int Beetles;

        [SerializeField]
        private GameObject _pickup4_Panel;

        public void AddBeetle()
        {
            Beetles++;
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
                _pickup4_Panel.SetActive(true);
                _inventory.UpdatePickupText();
                yield return new WaitForSeconds(4f);
                _pickup4_Panel.SetActive(false);
                yield break;
            }
        }



        private IEnumerator ShowPopUpText()
        {
            var fadingTime = 2f;

            while (true)
            {
                _HUD._Pop_up_beetleText.enabled = true;
                yield return new WaitForSeconds(2f);
                _HUD._Pop_up_beetleText.color = Color.Lerp(new Color(0, 1, 0, 1), new Color(0, 1, 0, 0), fadingTime);
                yield return new WaitForSeconds(1f);
                _HUD._Pop_up_beetleText.enabled = false;
                _HUD._Pop_up_beetleText.color = Color.Lerp(new Color(0, 1, 0, 0), new Color(0, 1, 0, 1), fadingTime);

                yield break;
            }

        }
    }
}


