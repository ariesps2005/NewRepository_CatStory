using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CatStory
{
    public class ContinueButton : MonoBehaviour
    {


        [SerializeField]
        private TMP_Text _continueText;

        [SerializeField]
        private SpriteRenderer _pawSprite;

        public void OnButton()
        {
            _continueText.color = Color.white;
            _pawSprite.enabled= true;
        }

        public void OnExitButton()
        {
            _continueText.color = new Color32(0x38, 0x38, 0x38, 0xFF);
            _pawSprite.enabled = false;
        }


    }
}
