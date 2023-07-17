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

        //public EndOfLevel_2 _endOfLevelCollider2;

        //public EndOfLevel_3 _endOfLevelCollider3;

        //public EndOfLevel_4 _endOfLevelCollider4;

        public GameObject _playerPosition_Part2;

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

        

    }
}
