using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CatStory
{

    public class FieldDescriptionLimiter : MonoBehaviour
    {
        private PlayerController _player;

        private AbilityPicture _ability;

        //-----------Ability Serialize FD Fields-----
        [SerializeField]
        private GameObject _fieldAbility1;

        [SerializeField]
        private GameObject _fieldAbility2;

        //[SerializeField]
        //private GameObject _fieldAbility3;

        //[SerializeField]
        //private GameObject _fieldAbility4;

        //[SerializeField]
        //private GameObject _fieldAbility5;

        //-----------Main--------------
        private void Awake()
        {
            _player = FindObjectOfType<PlayerController>();
            _ability = FindObjectOfType<AbilityPicture>();
        }

      

        public void HideField()
        {
            if (!_player._hasPowerMeow)//if player doesn't have an ability
            {
                _ability.isAble = false;
                _fieldAbility1.SetActive(false);
                
            }
            else//if player HAS an ability
            {
                _ability.isAble = true;
                _fieldAbility1.SetActive(true);
            }

            if (!_player._hasDoubleJump)//if player doesn't have an ability
            {
                _ability.isAble = false;
                _fieldAbility2.SetActive(false);

            }
            else//if player HAS an ability
            {
                _ability.isAble = true;
                _fieldAbility2.SetActive(true);
            }

        }




    }
}
