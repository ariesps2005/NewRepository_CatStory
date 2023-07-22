using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace CatStory
{

    public class SettingsController : MonoBehaviour
    {
        [SerializeField]
        private Slider _musicVolumeSlider;

        [SerializeField]
        private Slider _soundsVolumeSlider;

        [SerializeField]
        private SpriteRenderer _pawSprite;

        [SerializeField]
        private Button _button;

        [SerializeField]
        private TMP_Text _buttonText;

        

        public void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void BackToGame()
        {
            SceneManager.LoadScene(1);
        }

        public void OnButton()
        {
            _buttonText.color = Color.white;
            _pawSprite.enabled = true;
        }

        public void OnButtonExit()
        {
            _buttonText.color = new Color32(0x38, 0x38, 0x38, 0xFF);
            _pawSprite.enabled = false;
        }




    }
}
