using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CatStory
{

    public class AbilityPicture : MonoBehaviour
    {

        private PlayerController _player;
                
        [SerializeField]
        private Image _abilityPicture;
                
        [SerializeField]
        private GameObject _field;

        public float VectorMultiplier = 1.45f;

        public bool isAble = false;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerController>();
        }

        private void Start()
        {
            _field.SetActive(false);
        }

        public void Hover()
        {
            _abilityPicture.transform.localScale
                = new Vector3(0.39f * VectorMultiplier, 0.39f * VectorMultiplier, 0.39f);
            
        }

        public void ExitHover()
        {
            _abilityPicture.transform.localScale = new Vector3(0.39f, 0.39f, 0.39f);
            


        }

        public void Click()
        {
            
            if (_field != null && _player._hasPowerMeow) 
                {
                _field.SetActive(true);
                _abilityPicture.transform.localScale
                = new Vector3(0.39f * VectorMultiplier, 0.39f * VectorMultiplier, 0.39f);
            }

            
        }

        public void ExitClick()
        {
            if (_field != null && _player._hasPowerMeow)
            {
                _field.SetActive(false);
                _abilityPicture.transform.localScale = new Vector3(0.39f, 0.39f, 0.39f);
            }

        

        }
    }
}
