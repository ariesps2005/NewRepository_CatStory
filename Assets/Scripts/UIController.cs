using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace CatStory
{
    public class UIController : MonoBehaviour
    {
        [Header("Pickup Controllers")]
        [SerializeField]
        private LifeManager _lifeController;

        [SerializeField]
        private FrankfurterManager _frankfurterController;
        [SerializeField]
        private ChickenManager _chickenController;
        [SerializeField]
        private CheeseManager _cheeseController;
        [SerializeField]
        private BeetleManager _beetleController;
        //[SerializeField]
        //private FrankfurterManager _fireflyController;

        [Header("Pickup Texts")]
        [Space, SerializeField]
        private TMP_Text _lifeText;

        [SerializeField]
        private TMP_Text _frankfurterText;
        [SerializeField]
        private TMP_Text _chickenText;
        [SerializeField]
        private TMP_Text _cheeseText;
        [SerializeField]
        private TMP_Text _beetleText;
        //[SerializeField]
        //private TMP_Text _fireflyText;

        //------------UI Pop-Up Texts---------

        [Header("Pop-Up Pickup Texts")]
        //-life
        public TMP_Text _Pop_up_lifeText;

        //-pickups--
        public TMP_Text _Pop_up_frankfurterText;
        
        public TMP_Text _Pop_up_chickenText;
        
        public TMP_Text _Pop_up_cheeseText;
        
        public TMP_Text _Pop_up_beetleText;
        
        public TMP_Text _Pop_up_fireflyText;

        [Header("Pickup Ability Panels")]

        public Image _frankfurterPanel;
        public GameObject _frankAbilityPic;
        public TMP_Text _frankAbilityText;

        public Image _chickenPanel;
        public Image _cheesePanel;
        public Image _beetlePanel;
        public Image _fireflyPanel;


        private void Awake()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            _lifeText.text = _lifeController.Lives.ToString();

            _frankfurterText.text = _frankfurterController.Frankfurters.ToString();
            _chickenText.text = _chickenController.ChickenLegs.ToString();
            _cheeseText.text = _cheeseController.Cheese.ToString();
            //_beetleText.text = _beetleController.Beetle.ToString();
            //_fireflyText.text = _fireflyController.Firefly.ToString();

        }
    }
}
