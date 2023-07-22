using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CatStory
{
    public class InGameMenuController : MonoBehaviour
    {

        [SerializeField]
        private GameManager _gameManager;

        [SerializeField]
        private Button _mainMenuButton;

        [SerializeField]
        private Button _resumeButton;

        [SerializeField]
        private Button _loadButton;

        [SerializeField]
        private Button _settingsButton;

        [SerializeField]
        private Button _quitButton;

        //---------------Button Functions----------
        public void ToMainmenu()
        {
            SceneManager.LoadScene(0);
        }

        public void StartLevel()
        {
            SceneManager.LoadScene(1);
        }

        public void OnResume()
        {
            _gameManager._inGameMenuScreen.SetActive(false);
        }

        public void OnLoadSave()
        {
            //to do after saving and loading implementation;
        }

        public void ToSettingsMenu()
        {
            SceneManager.LoadScene(2);
        }

        public void OnQuit()
        {
            Application.Quit();
        }
    }
}
