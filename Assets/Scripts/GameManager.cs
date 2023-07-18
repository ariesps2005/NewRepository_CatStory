using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;

namespace CatStory
{


    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player;

        [Space,SerializeField]
        private SavePoint[] _savePoints;

        [Header("End Of Levels")]
        [SerializeField]
        private GameObject _finishTreeMarker;

        
        public EndOfLevel_1 _endOfLevelCollider;

        public EndOfLevel_2 _endOfLevelCollider2;

        //public EndOfLevel_3 _endOfLevelCollider3;

        //public EndOfLevel_4 _endOfLevelCollider4;

        public GameObject _playerPosition_Part2;

        public GameObject _playerPosition_Part3;

        [Header("Cinemachine")]
        [SerializeField]
        private CinemachineVirtualCamera cinemachineCam;
        

        [Space,Header("UIScreens")]
        [SerializeField]
        public GameObject _inGameMenuScreen;

        [SerializeField]
        public GameObject _inventoryScreen;

        [SerializeField]
        public GameObject _gameOverScreen;

        [SerializeField]
        public UIController _HUD;


        private bool isFirstDialogueOn = false;
        private bool isOwlDialogueOn = false;

        //-------------------Main Functions---------------

        private void Awake()
        {
            Time.timeScale = 1f;
            
            _savePoints = FindObjectsOfType<SavePoint>();
        }


        private void Start()
        {
            _gameOverScreen.SetActive(false);
            cinemachineCam = FindObjectOfType<CinemachineVirtualCamera>();
           
            
        }

        public void SaveProgress()
        {
            //to do saving... 
        }

        //-------------Managing Camera----------

        public void StopCameraAtFinishLevel1()
        {
            Debug.Log(cinemachineCam); 
            cinemachineCam.Follow = _finishTreeMarker.transform;
            cinemachineCam.GetComponentInChildren<CinemachineFramingTransposer>().m_TrackedObjectOffset.y = 0f;
        }

        public void ReturnToFollowPlayer()
        {
            cinemachineCam.Follow = _player.transform;
            cinemachineCam.GetComponentInChildren<CinemachineFramingTransposer>().m_TrackedObjectOffset.y = 2.5f;
        }

        public void StopCameraY()
        {
            cinemachineCam.GetComponentInChildren<CinemachineFramingTransposer>().m_DeadZoneHeight = 1.42f;
            cinemachineCam.GetComponentInChildren<CinemachineFramingTransposer>().m_SoftZoneHeight = 1.42f;
        }

        public void ReturnCameraY()
        {
            cinemachineCam.GetComponentInChildren<CinemachineFramingTransposer>().m_DeadZoneHeight = 0f;
            cinemachineCam.GetComponentInChildren<CinemachineFramingTransposer>().m_SoftZoneHeight = 0.8f;
        }

        //--------Show Part Titles-----------

        public void ShowPart1Title()
        {
            StartCoroutine(ShowPartITitle());
        }

        public void ShowPart2Title()
        {
            StartCoroutine(ShowPartIITitle());
        }

        public void ShowPart3Title()
        {
            StartCoroutine(ShowPartIIITitle());
        }

        public void ShowPart4Title()
        {

        }


        //-----------Dialogues-------------

        public void FirstDialogue()
        {
            if (!isFirstDialogueOn)
            {
                StartCoroutine(FirstDialogueCR());
            }
        }

        public void Ability1Message()
        {
            StartCoroutine(PowerMeowMessage());
        }

        public void OwlDialogue1()
        {
            
            if (!isOwlDialogueOn)
            {
                StartCoroutine(OwlToyMiceMessage());
            }
            
        }


        //---------------Calling UI Screens------------------

        public void OnInGameMenu(InputAction.CallbackContext context)
        {
            if(context.started && !_inGameMenuScreen.activeSelf)
            {
                _inGameMenuScreen.SetActive(true);
            }
            else if (context.started && _inGameMenuScreen.activeSelf)
            {
                _inGameMenuScreen.SetActive(false);
            }
        }

        public void OnInventory(InputAction.CallbackContext context)
        {
            if(context.started && !_inventoryScreen.activeSelf)
            {
                _inventoryScreen.SetActive(true);
            }
            else if (context.started && _inventoryScreen.activeSelf)
            {
                _inventoryScreen.SetActive(false);
            }
        }

        //-----------------Coroutines---------------
        //--------Part 1-----------
        
        
        private IEnumerator ShowPartITitle()
        {
            _HUD.part1.enabled = true;
            yield return new WaitForSeconds(4f);
            _HUD.part1.enabled = false;
        }

        private IEnumerator ShowPartIITitle()
        {
            _HUD.part2.enabled = true;
            yield return new WaitForSeconds(4f);
            _HUD.part2.enabled = false;
        }

        private IEnumerator ShowPartIIITitle()
        {
            _HUD.part3.enabled = true;
            yield return new WaitForSeconds(4f);
            _HUD.part3.enabled = false;
        }



        private IEnumerator FirstDialogueCR()
        {

            isFirstDialogueOn = true; 
            _HUD.messageText.text = _HUD._birdMessage1;
            yield return new WaitForSeconds(6f);
            _HUD.messageText.text = _HUD._birdMessage2;
            yield return new WaitForSeconds(6f);
            _HUD.messageText.text = "";


        }

        private IEnumerator PowerMeowMessage()
        {
            if (isFirstDialogueOn)
            {
                _HUD.messageText.text = _HUD._birdMessage3;
                yield return new WaitForSeconds(10f);
                _HUD.messageText.text = "";

            }



        }

        private IEnumerator OwlToyMiceMessage()
        {
            if (isFirstDialogueOn)
            {
                isOwlDialogueOn = true;
                _HUD.messageText.text = _HUD._owlMessage1;
                yield return new WaitForSeconds(6f);
                _HUD.messageText.text = _HUD._owlMessage2;
                yield return new WaitForSeconds(6f);
                _HUD.messageText.text = _HUD._owlMessage3;
                yield return new WaitForSeconds(6f);
                _HUD.messageText.text = "";

            }



        }

    }
}
