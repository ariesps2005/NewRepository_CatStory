using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CatStory
{
    public class StartButton : MonoBehaviour
    {

        [SerializeField]
        private TMP_Text _startText;

        [SerializeField]
        private SpriteRenderer _pawSprite;

        public void OnButton()
        {
            _startText.color = Color.white;
            _pawSprite.enabled = true;
        }

        public void OnExitButton()
        {
            _startText.color = new Color32(0x38, 0x38, 0x38, 0xFF);
            _pawSprite.enabled = false;
        }
    }
}

