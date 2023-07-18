
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CatStory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField]
        private PlayerController _player;

        private void Awake()
        {
            //_player= FindObjectOfType<PlayerController>();

            
        }

        //---------Abilities---------
        //----Power Meow------
        [Header("Abilities")]
        [Header("Ability 1")]
        [SerializeField]
        public Image _ability1;
        
        [SerializeField]
        public Sprite _hiddenAbility1;

        [SerializeField]
        public Sprite _revealedAbility1;

        [SerializeField]
        public TMP_Text _ability1NameText;

        //----Double Jump-----------------------------------
        [Header("Ability 2")]
        [SerializeField]
        public Image _ability2;

        [SerializeField]
        public Sprite _hiddenAbility2;

        [SerializeField]
        public Sprite _revealedAbility2;

        public TMP_Text _ability2NameText;

        ////----Jump Attack--------------------------------------
        [Header("Ability 3")]
        [SerializeField]
        public Image _ability3;

        [SerializeField]
        public Sprite _hiddenAbility3;

        [SerializeField]
        public Sprite _revealedAbility3;

        public TMP_Text _ability3NameText;

        ////----Dash----------------------------------------

        [Header("Ability 4")]
        [SerializeField]
        public Image _ability4;

        [SerializeField]
        public Sprite _hiddenAbility4;

        [SerializeField]
        public Sprite _revealedAbility4;

        public TMP_Text _ability4NameText;

        ////----Transform------

        //[Header("Ability 5")]
        //[SerializeField]
        //public Image _ability5;

        //[SerializeField]
        //public Sprite _hiddenAbility5;

        //[SerializeField]
        //public Sprite _revealedAbility5;

        //public TMP_Text _ability5NameText;



        //----------Pickups-----------
        //----------Frankurters-------
        [Header("Pickups")]
        [SerializeField]
        public FrankfurterManager _frankfurterManager;

        [SerializeField]
        public Image _pickup1Frankfurter;

        [SerializeField]
        public Sprite _hiddenPickup1;

        [SerializeField]
        public Sprite _revealedPickup1;

        [SerializeField]
        public Sprite _activeFrankAbility;

        [SerializeField]
        public TMP_Text _frankfurterNameText;

        [SerializeField]
        public TMP_Text _frankfurterText;

        //----------Chicken Legs-------
        [Space, SerializeField]
        public ChickenManager _chickenManager;

        [SerializeField]
        public Image _pickup2Chicken;

        [SerializeField]
        private Sprite _hiddenPickup2;

        [SerializeField]
        public Sprite _revealedPickup2;

        [SerializeField]
        public Sprite _activeChickenAbility;

        [SerializeField]
        public TMP_Text _chickenNameText;

        [SerializeField]
        public TMP_Text _chickenText;

        //----------Cheese-------
        [Space, SerializeField]
        public CheeseManager _cheeseManager;

        [SerializeField]
        public Image _pickup3Cheese;

        [SerializeField]
        public Sprite _hiddenPickup3;

        [SerializeField]
        public Sprite _revealedPickup3;

        [SerializeField]
        public Sprite _activeCheeseAbility;

        [SerializeField]
        public TMP_Text _cheeseNameText;

        [SerializeField]
        public TMP_Text _cheeseText;

        //----------Beetles-------
        [Space, SerializeField]
        public BeetleManager _beetlesManager;

        [SerializeField]
        public Image _pickup4beetle;

        [SerializeField]
        public Sprite _hiddenPickup4;

        [SerializeField]
        public Sprite _revealedPickup4;

        [SerializeField]
        public Sprite _activeBeetleAbility;

        [SerializeField]
        public TMP_Text _beetleNameText;

        [SerializeField]
        public TMP_Text _beetleText;

        //----------Fireflies-------
        [Space, SerializeField]
        public FireflyManager _firefliesManager;

        [SerializeField]
        public Image _pickup5firefly;

        [SerializeField]
        private Sprite _hiddenPickup5;

        [SerializeField]
        public Sprite _revealedPickup5;

        [SerializeField]
        public Sprite _activeFireflyAbility;

        [SerializeField]
        public TMP_Text _fireflyNameText;

        [SerializeField]
        public TMP_Text _fireflyText;


        //------------Main------------
        public void UpdatePickupText()
        {
            Debug.Log(_frankfurterManager);
            Debug.Log(_frankfurterText);
            Debug.Log(_frankfurterNameText);
            Debug.Log(_player);
            Debug.Log(_player._pickup1);


            
            _frankfurterText.text = _frankfurterManager.Frankfurters.ToString();
            _chickenText.text = _chickenManager.ChickenLegs.ToString();
            _cheeseText.text = _cheeseManager.Cheese.ToString();
            _beetleText.text = _beetlesManager.Beetles.ToString();
            _fireflyText.text = _firefliesManager.Fireflies.ToString();


            if (_player._pickup1)
            {
                _frankfurterNameText.enabled = true;
            }
            else
            {
                _frankfurterNameText.enabled = false;
            }

            if (_player._pickup2)
            {
                _chickenNameText.enabled = true;
            }
            else
            {
                _chickenNameText.enabled = false;
            }

            if (_player._pickup3)
            {
                _cheeseNameText.enabled = true;
            }
            else
            {
                _cheeseNameText.enabled = false;
            }

            if (_player._pickup4)
            {
                _beetleNameText.enabled = true;
            }
            else
            {
                _beetleNameText.enabled = false;
            }

            if (_player._pickup5)
            {
                _fireflyNameText.enabled = true;
            }
            else
            {
                _fireflyNameText.enabled = false;
            }


        }






    }
}
