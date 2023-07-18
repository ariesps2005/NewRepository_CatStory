using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace CatStory
{
    public class SettingsButton : MonoBehaviour
    {

        [SerializeField]
        private TMP_Text _settingsText;

        [SerializeField]
        private SpriteRenderer _pawSprite;

        public void OnButton()
        {
            _settingsText.color = Color.white;
            _pawSprite.enabled = true;
        }

        public void OnExitButton()
        {
            _settingsText.color = new Color32(0x38, 0x38, 0x38, 0xFF);
            _pawSprite.enabled = false;
        }
    }
}
