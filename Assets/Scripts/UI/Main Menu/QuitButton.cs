using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace CatStory
{
    public class QuitButton : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _quitText;

        [SerializeField]
        private SpriteRenderer _pawSprite;

        public void OnButton()
        {
            _quitText.color = Color.white;
            _pawSprite.enabled = true;
        }

        public void OnExitButton()
        {
            _quitText.color = new Color32(0x38, 0x38, 0x38, 0xFF);
            _pawSprite.enabled = false;
        }
    }
}
