using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

namespace CatStory
{
    public class MainMenuController : MonoBehaviour
    {
        [Header ("Buttons")]
        [SerializeField]
        private Button _startButton;

        [SerializeField]
        private Button _continueButton;

        [SerializeField]
        private Button _settingsButton;

        [SerializeField]
        private Button _quitButton;

      

        //[Header("Audio")]
        //[SerializeField]
        //private AudioSource _buttonSound;

        //[SerializeField]
        //private AudioSource menuMusic;



        public void LoadNewLevelScene()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadSavedLevelScene()
        {
            //to do after saving and loading implementation
        }

        public void LoadSettingsScene()
        {
            SceneManager.LoadScene(2);
        }

        public void QuitGame()
        {
            EditorApplication.isPlaying = false;
        }

  


    }
}


