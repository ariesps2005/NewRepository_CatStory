using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

namespace CatStory

{
    [RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
    public class PlayerController : MonoBehaviour
    {
        AudioSource audioSource;

        private Vector2 moveInput;
        private TouchingDirections touchingDirections;
        private GameManager _gameManager;

        [SerializeField]
        private ParticleSystem _dust;


        [SerializeField]
        private InventoryController _inventory;

        [Header("Player Refs")]
        [SerializeField]
        private Rigidbody2D _playerRB;
        [SerializeField]
        private float _playerSpeed;
        [SerializeField]
        public Animator _playerAnim;
        [SerializeField]
        private SpriteRenderer _playerSprite;

        [Header("Jump")]
        //[SerializeField]
        //private bool canJump = true;
        [SerializeField]
        private float jumpImpulse = 10f;
        [SerializeField]
        private float doublejumpImpulse = 5f;
        [SerializeField]
        private int currentJumps;
        [SerializeField]
        private int maxJumps = 2;
        public float fallMultiplier = 2.5f;

        [SerializeField]
        private AudioSource _jump;

        [Header("Dash")]
        [SerializeField]
        private TrailRenderer _dashTrail;

        [SerializeField]
        private bool canDash = true;

        [SerializeField]
        private float dashingPower = 25f;
        [SerializeField]
        private float dashingTime = 0.2f;
        [SerializeField]
        private float dashingCooldown = 1f;

        [SerializeField]
        private AudioSource _dash;

        [Header("Life and Save")]
        [Space, SerializeField]
        private LifeManager _lifeManager;
        private SavePoint _savePoint;

        [SerializeField]
        private Collider2D _savePointFinish;

        [SerializeField]
        private PoisonSpitProjectile _snakeSpit;

        private Obstacle _obstacle;

        [Header("Power Meow")]
        [Space, SerializeField]
        private PowerMeowSoundWave _meowPrefab;
        [SerializeField]
        private Transform _meowFirePoint;
        [SerializeField]
        private AudioSource _powerMeowSound;


        [Header("Markers")]
        [Space, SerializeField]
        private TreeFinishMarker _treeFinishMarker;

        private bool _isMoving = false;
        private bool _isJumping = false;
        private bool _isDashing = false;
        public bool _isFacingRight = true;
        public bool _isGrounded = true;

        public bool isInvulnerable;
        public bool isDead = false;

        private float _damageTime = 0.1f;
        private float _poisondamagePlayerTime = 0.1f;
        private float _obstacleDamageTime = 0.1f;


        //-----------private Ability Refs-----------
        [Header("Ability Refs")]
        [SerializeField]
        private AudioSource _openAbilityBox;

        [Header("Ability 1")]
        [SerializeField]
        private AbilityBox_1_Meow _abilityBox_1;
        [SerializeField]
        private Animator _ability1_animator;
        [Header("Ability 2")]
        [SerializeField]
        private AbilityBox_2_DJump _abilityBox_2;
        [SerializeField]
        private Animator _ability2_animator;
        //[Header("Ability 3")]
        //[SerializeField]
        //private AbilityBox_3_Block _abilityBox_3;
        //[SerializeField]
        //private Animator _ability3_animator;
        //[Header("Ability 4")]
        //[SerializeField]
        //private AbilityBox_4_Dash _abilityBox_4;
        //[SerializeField]
        //private Animator _ability4_animator;
        //[Header("Ability 5")]
        //[SerializeField]
        //private AbilityBox_5_Transform _abilityBox_5;
        //[SerializeField]
        //private Animator _ability5_animator;

        //-------------Public Ability Bools----------
        [Header("Abilities")]
        public bool _hasPowerMeow = false;
        public bool _hasDoubleJump = false;
        public bool _hasJumpAttack = false;
        //public bool _hasDash = false;
        //public bool _hasTransform = false;


        //-------------Pickup Managers-------
        [Header("Pickup Managers")]
        [SerializeField]
        private FrankfurterManager _frankfurterManager;
        [SerializeField]
        private ChickenManager _chickenManager;
        [SerializeField]
        private CheeseManager _cheeseManager;
        [SerializeField]
        private BeetleManager _beetleManager;
        //[SerializeField]
        //private FireflyManager _fireflyManager;


        //-------------Public Pickup Bools------------
        [Header("Pickups")]
        public bool _pickup1;
        public bool _pickup2;
        public bool _pickup3;
        public bool _pickup4;
        public bool _pickup5;

        //-----------Public Pickup Abilities Bools---------
        [Header("Pickup Abilities")]
        public bool _frankAbilityIsReady;
        public bool _chickenAbilityIsReady;
        public bool _cheeseAbilityIsReady;
        public bool _beetleAbilityIsReady;
        //public bool _fireflyAbilityIsReady;

        //-------------Movement Bool Properties------------
        public bool IsMoving
        {
            get
            {
                return _isMoving;
            }

            private set
            {
                _isMoving = value;
                _playerAnim.SetBool(AnimationStrings.isMoving, value);
            }
        }

        public bool IsJumping
        {
            get
            {
                return _isJumping;
            }

            private set
            {
                _isJumping = value;
                _playerAnim.SetTrigger("jump");
            }
        }

        public bool IsFacingRight
        {
            get
            {
                return _isFacingRight;
            }
            private set
            {
                if (_isFacingRight != value)
                {
                    transform.localScale *= new Vector2(-1, 1);
                }

                _isFacingRight = value;
            }
        }

        public bool IsGrounded
        {
            get
            {
                return _isGrounded;
            }

            set
            {
                _isGrounded = value;
            }
        }

        // ------------Main functions---------------
        private void Awake()//getting refs in Awake
        {
            _gameManager = FindObjectOfType<GameManager>();
            touchingDirections = GetComponent<TouchingDirections>();
            _treeFinishMarker = FindObjectOfType<TreeFinishMarker>();
            _savePoint = FindObjectOfType<SavePoint>();
            _obstacle = GetComponent<Obstacle>();

            _abilityBox_1 = FindObjectOfType<AbilityBox_1_Meow>();
            _abilityBox_2 = FindObjectOfType<AbilityBox_2_DJump>();
            //_abilityBox_3 = FindObjectOfType<AbilityBox_3_Block>();
            //_abilityBox_4 = FindObjectOfType<AbilityBox_4_Dash>();
            //_abilityBox_5 = FindObjectOfType<AbilityBox_5_Transform>();
        }


        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {

            if (_isDashing)
            {
                return;
            }

            _playerRB.WakeUp();
            //Debug.Log(_playerRB.velocity.y);
        }

        private void FixedUpdate()
        {
            if (_isDashing)
            {
                return;
            }



            _playerRB.velocity
                = new Vector2(moveInput.x * _playerSpeed * Time.fixedDeltaTime, _playerRB.velocity.y);
        }

        //----------Movement Functions---------------
        public void OnMove(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();

            IsMoving = moveInput != Vector2.zero;

            SetFacingDirection(moveInput);
        }

        private void SetFacingDirection(Vector2 moveInput)
        {
            if (moveInput.x > 0 && !IsFacingRight)
            {
                IsFacingRight = true;
            }

            if (moveInput.x < 0 && IsFacingRight)
            {
                IsFacingRight = false;
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _jump.Play();
            }
            
           
            if (context.started &&
                !_hasDoubleJump && touchingDirections.IsGrounded && _lifeManager.Lives > 0)//single jump
            {
                _playerAnim.SetTrigger(AnimationStrings.jump);

                _playerRB.velocity = new Vector2(_playerRB.velocity.x, jumpImpulse * Time.fixedDeltaTime);
                currentJumps++;



                if (_playerRB.velocity.y < 0)
                {
                    _playerRB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
                    Debug.Log("Physics2D works!");
                }


            }
            else if (context.performed && _hasDoubleJump && currentJumps < maxJumps)//double jump
            {
                _playerAnim.SetTrigger(AnimationStrings.jump);
                _playerRB.velocity = new Vector2(_playerRB.velocity.x, (jumpImpulse + doublejumpImpulse) * Time.fixedDeltaTime);
                currentJumps++;


            }

            if (touchingDirections.IsGrounded)
            {
                _dust.Play();
                currentJumps = 1;
            }
            if (currentJumps == maxJumps) return;

            SetFacingDirection(moveInput);


        }


        public void OnBlock()//to do
        {

        }

        public void OnDash(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _dash.Play();
            }
            
            
            if (context.started && canDash && !_isDashing && _lifeManager.Lives > 0)
            {
                StartCoroutine(DashCoroutine());
            }

            SetFacingDirection(moveInput);

        }

        //-----------------Attack Functions-----------

        public void OnAttack(InputAction.CallbackContext context)
        {

            if (context.started)
            {
                _playerAnim.SetTrigger(AnimationStrings.meleeAttack);
            }

            SetFacingDirection(moveInput);
        }

        public void OnMeowAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _powerMeowSound.Play();
            }
            
            
            if (context.started && _hasPowerMeow && touchingDirections.IsGrounded)
            {
                _playerAnim.SetTrigger(AnimationStrings.meowAttack);
                Instantiate(_meowPrefab, _meowFirePoint.position, Quaternion.Euler(new Vector2(0, 0)));


            }
            SetFacingDirection(moveInput);

            if (context.started && _hasPowerMeow && _hasJumpAttack)//aerial PowerMeow attack
            {
                _playerAnim.SetTrigger(AnimationStrings.meowAttack);
                Instantiate(_meowPrefab, _meowFirePoint.position, Quaternion.Euler(new Vector2(0, 0)));
            }

        }

        public void OnTransformation()//to do
        {

        }


        //-------------On Interaction Functions-------------

        public void OnInteractionSave(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                //save the progress
            }
        }

        public void OnFrankfurterAbility(InputAction.CallbackContext context)
        {
            if (context.started && _frankAbilityIsReady)
            {
                _frankfurterManager.TurnFrankfurterAbility();
            }
        }


        //---------------------------------COLLIDING---------------------------------------------------


        public void OnTriggerEnter2D(Collider2D collision)
        {

            //----------Getting Enemy Damage---------

            if (collision.GetComponent<Enemy_Class>() && !isInvulnerable && !isDead)
            {
                StartCoroutine(EnemyHarm());


            }


            //-----------Getting Poison Damage-----------

            if (collision.GetComponent<PoisonSpitProjectile>() && !isInvulnerable && !isDead)
            {
                StartCoroutine(PoisonHarm());

                if (_lifeManager.Lives <= 0)
                {
                    _lifeManager.Die();
                }
            }

            //-----------Getting Obstacle Damage------------

            if (collision.GetComponent<Obstacle>() && !isInvulnerable && !isDead)
            {
                StartCoroutine(ObstacleHarm());

                if (_lifeManager.Lives <= 0)
                {
                    _lifeManager.Die();
                }
            }

            //stopping camera at the end of this part of level 

            if (collision.GetComponent<TreeFinishMarker>() && _treeFinishMarker != null && !isDead)
            {
                _gameManager.StopCameraAtFinishLevel1();

            }


            //going to Part 2 of Level

            if (collision.GetComponent<EndOfLevel_1>() && _gameManager._endOfLevelCollider != null && !isDead)
            {
                transform.position = _gameManager._playerPosition_Part2.transform.position;
                _gameManager.ReturnToFollowPlayer();
            }



            //--------Getting Abilities----------
            //---------Power Meow---------
            if (collision.GetComponent<AbilityBox_1_Meow>() && _abilityBox_1 != null && !isDead)
            {
                _openAbilityBox.Play();
                StartCoroutine(OpenAbilityBox_1());


                _hasPowerMeow = true;
                _inventory._ability1.sprite = _inventory._revealedAbility1;
                _inventory._ability1NameText.SetText("Power Meow");

            }

            //---------Double Jump-------- -
            if (collision.GetComponent<AbilityBox_2_DJump>() && _abilityBox_2 != null && !isDead)
            {
                _openAbilityBox.Play();
                StartCoroutine(OpenAbilityBox_2());

                _hasDoubleJump = true;
                _inventory._ability2.sprite = _inventory._revealedAbility2;
                _inventory._ability2NameText.SetText("Double Jump");
            }

            //---------JumpAttack---------
            //if (collision.GetComponent<AbilityBox_3_JAttack>() && _abilityBox_3 != null && !isDead)
            //{
            //   _hasJumpAttack = true;

            //_inventory._ability3.sprite = _inventory._revealedAbility3;
            //_inventory._ability3NameText.SetText("Jump Attack");

            //}

            //---------Dash---------
            //if (collision.GetComponent<AbilityBox_4_Dash>() && _abilityBox_4 != null && !isDead)
            //{
            //   _hasDash = true;

            //_inventory._ability4.sprite = _inventory._revealedAbility4;
            //_inventory._ability4NameText.SetText("Dash Leap");
            //}

            //---------Transform---------
            //if (collision.GetComponent<AbilityBox_5_Transform>() && _abilityBox_5 != null && !isDead)
            //{
            // _hasTransform = true;

            //_inventory._ability5.sprite = _inventory._revealedAbility5;
            //_inventory._ability5NameText.SetText("Super Cat");
            //}




        }



        //highlighting the SavePoint Sprite

        public void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.GetComponent<SavePoint>() && _savePoint != null && !isDead)
            {
                _savePoint.HighlightSprite();

            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.GetComponent<SavePoint>() && _savePoint != null && !isDead)
            {
                _savePoint.DeactivateHighlightSprite();

            }
        }

        //----------------------COROUTINES--------------------------------------

        //------------Movement Coroutines-----------

        //----------Dash Coroutine---------

        private IEnumerator DashCoroutine() 
        {

           

            if (!_isFacingRight)
            {
                canDash = false;
                _isDashing = true;
                float origGravity = _playerRB.gravityScale;
                _playerRB.gravityScale = 0f;
                //_playerRB.velocity = new Vector2(transform.position.x * dashingPower, 0f);
                _playerRB.velocity = Vector2.left * dashingPower;
                _dashTrail.emitting = true;
                yield return new WaitForSeconds(dashingTime);
                _playerRB.gravityScale = origGravity;
                _isDashing = false;
                _dashTrail.emitting = false;
                yield return new WaitForSeconds(dashingCooldown);
                canDash = true;


            }
            else
            {
                canDash = false;
                _isDashing = true;
                float origGravity = _playerRB.gravityScale;
                _playerRB.gravityScale = 0f;
                //_playerRB.velocity = new Vector2(-transform.position.x * dashingPower, 0f);
                _playerRB.velocity = Vector2.right * dashingPower;
                _dashTrail.emitting = true;
                yield return new WaitForSeconds(dashingTime);
                _playerRB.gravityScale = origGravity;
                _isDashing = false;
                _dashTrail.emitting = false;
                yield return new WaitForSeconds(dashingCooldown);
                canDash = true;
            }

         
            


        }


        //-------------HARM-------------

        //-----------Getting Enemy Harm----------

        public IEnumerator EnemyHarm()
        {
            if (!isDead)
            {
                _lifeManager.Lives -= 1;

                var time = _damageTime;
                while (time > 0 && !isDead)
                {
                    StartCoroutine(SetInvulnerability());
                    _playerSprite.enabled = !_playerSprite.enabled;
                    _playerSprite.color = new Color32(0xBC, 0x3A, 0x3A, 0xFF);
                    time -= Time.deltaTime;
                    yield return new WaitForSeconds(0.1f);
                }
                _playerSprite.color = Color.white;
                _playerSprite.enabled = true;
            }


        }

        //--------Getting Poison Harm-----

        private IEnumerator PoisonHarm()
        {
            if (!isDead)
            {
                _lifeManager.Lives -= 1;

                var time = _poisondamagePlayerTime;
                while (time > 0)
                {

                    StartCoroutine(SetInvulnerability());
                    _playerSprite.enabled = !_playerSprite.enabled;
                    _playerSprite.color = Color.green;
                    time -= Time.deltaTime;
                    yield return new WaitForSeconds(0.1f);

                }

                _playerSprite.enabled = true;
                Debug.Log("Poisoning");

            }


        }

        //----------Getting Obstacle Harm-------
        private IEnumerator ObstacleHarm()
        {
            _lifeManager.Lives -= 1;
            var time = _obstacleDamageTime;

            while (time > 0)
            {
                StartCoroutine(SetInvulnerability());
                _playerSprite.enabled = !_playerSprite.enabled;
                _playerSprite.color = new Color32(0xBC, 0x3A, 0x3A, 0xFF);
                time -= Time.deltaTime;
                yield return new WaitForSeconds(_obstacleDamageTime);

            }
            _playerSprite.color = Color.white;
            _playerSprite.enabled = true;
            Debug.Log("Obstacle Harm");
        }

        //--------Invulnerability--------

        public IEnumerator SetInvulnerability(float invTime = 2f)
        {
            isInvulnerable = true;
            yield return new WaitForSeconds(invTime);
            isInvulnerable = false;
        }


        //--------Abilities-------------


        public IEnumerator OpenAbilityBox_1()
        {
            while (true)
            {
                _ability1_animator.SetTrigger("opened");
                yield return new WaitForSeconds(30f);
                _abilityBox_1.gameObject.SetActive(false);


            }
        }

        public IEnumerator OpenAbilityBox_2()
        {
            while (true)
            {
                _ability2_animator.SetTrigger("opened");
                _abilityBox_2.GetComponent<BoxCollider2D>().enabled = false;
                yield return new WaitForSeconds(30f);
                _abilityBox_2.gameObject.SetActive(false);


            }
        }

        //public IEnumerator OpenAbilityBox_3()
        //{
        //    while (true)
        //    {
        //        _ability3_animator.SetTrigger("opened");
        //        yield return new WaitForSeconds(2f);
        //        _abilityBox_3.gameObject.SetActive(false);


        //    }
        //}

        //public IEnumerator OpenAbilityBox_4()
        //{
        //    while (true)
        //    {
        //        _ability4_animator.SetTrigger("opened");
        //        yield return new WaitForSeconds(2f);
        //        _abilityBox_4.gameObject.SetActive(false);


        //    }
        //}
        //public IEnumerator OpenAbilityBox_5()
        //{
        //    while (true)
        //    {
        //        _ability5_animator.SetTrigger("opened");
        //        yield return new WaitForSeconds(2f);
        //        _abilityBox_5.gameObject.SetActive(false);


        //    }
        //}
    }





}


    






















