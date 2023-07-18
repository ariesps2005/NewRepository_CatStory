using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CatStory
{
    public class PickupPicture : MonoBehaviour
    {
        private PlayerController _player;
        
        [SerializeField]
        private Image _pickupPicture;

        [SerializeField]
        private GameObject _field;



        public float VectorMultiplier = 1.45f;

        private void Start()
        {
            _field.SetActive(false);
            _player = FindObjectOfType<PlayerController>();
        }

        public void Hover()
        {
            _pickupPicture.transform.localScale
                = new Vector3(0.39f * VectorMultiplier, 0.39f * VectorMultiplier, 0.39f);

        }

        public void ExitHover()
        {
            _pickupPicture.transform.localScale = new Vector3(0.39f, 0.39f, 0.39f);



        }

        public void Click()
        {
            if (_field != null && _player._pickup1)
            {
                _field.SetActive(true);
                _pickupPicture.transform.localScale
                = new Vector3(0.39f * VectorMultiplier, 0.39f * VectorMultiplier, 0.39f);
            }

        }

        public void ExitClick()
        {
            if (_field != null && _player._pickup1)
            {
                _field.SetActive(false);
                _pickupPicture.transform.localScale = new Vector3(0.39f, 0.39f, 0.39f);
            }

        }
    }
}

