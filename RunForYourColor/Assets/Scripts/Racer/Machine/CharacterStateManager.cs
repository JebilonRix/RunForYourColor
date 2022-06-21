using UnityEngine;

namespace RedPanda.StateMachine
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    public class CharacterStateManager : MonoBehaviour
    {
        #region Fields
        //States
        private CharacterBaseState currentState;
        public CharacterIdleState IdleState = new CharacterIdleState();
        public CharacterRunState RunState = new CharacterRunState();
        public CharacterJumpState JumpState = new CharacterJumpState();
        public CharacterClimbState ClimbState = new CharacterClimbState();

        [Header("Climbing")]
        [SerializeField] private string _wallTag = "Wall";
        [SerializeField] private float _wallOffset = 1f;

        [Header("Horizontal Movement")]
        [SerializeField] private float _speed = 7;
        [SerializeField] private float _horizontalSpeed = 0.3f;

        [Header("Vertical Movement")]
        [SerializeField] private float _jumpForce = 10;
        [SerializeField] private string _groundTag = "Ground";
        [SerializeField] private float _groundOffSet = 0.5f;

        [Header("Visual Stuff")]
        [SerializeField] private Animator _animator;

        private string _colorType;
        private float _lastFrameFingerPositionX = 0;
        private float _moveFactorX = 0;
        private Rigidbody _rb;
        private MeshRenderer _meshRenderer;
        private bool _startRun = false;
        #endregion Fields

        #region Properties
        public string ColorType { get => _colorType; set => _colorType = value; }
        public Rigidbody Rb { get => _rb; private set => _rb = value; }
        public bool StartRun { get => _startRun; set => _startRun = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public float JumpForce { get => _jumpForce; }
        public string GroundTag { get => _groundTag; }
        public float GroundOffSet { get => _groundOffSet; }
        #endregion Properties

        #region Unity Methods
        private void Awake()
        {
            if (Rb == null)
            {
                Rb = GetComponent<Rigidbody>();
            }
            if (_animator == null)
            {
                _animator = GetComponent<Animator>();
            }

            gameObject.tag = "Racer";
        }
        private void Start()
        {
            SwitchState(IdleState);
        }
        private void Update()
        {
            currentState.UpdateState(this);

            if (Input.GetMouseButtonDown(0))
            {
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _moveFactorX = 0f;
            }

            transform.Translate(new Vector3(_moveFactorX * _horizontalSpeed * Time.deltaTime, 0, 0));
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        private void FixedUpdate()
        {
            currentState.FixedUpdateState(this);
        }
        #endregion Unity Methods

        #region Public Methods
        public void SwitchState(CharacterBaseState state)
        {
            if (currentState != null)
            {
                //Exit last state
                currentState.ExitState(this);
            }

            //Enter new state
            currentState = state;
            currentState.EnterState(this);
        }
        public void WallCheck()
        {
            if (Physics.Raycast(new Ray(transform.position, Vector3.forward), out RaycastHit _hit))
            {
                if (_hit.collider.CompareTag(_wallTag))
                {
                    if (_hit.distance <= _wallOffset)
                    {
                        SwitchState(ClimbState);
                    }
                }
                else if (_hit.collider.CompareTag("ClimbPoint"))
                {
                    SwitchState(RunState);
                }
            }
        }
        public void UpdateSpeed(float amount)
        {
            _speed += amount;
        }
        public void ChangeColor(string colorTypes)
        {
            switch (colorTypes.ToLower())
            {
                case "blue":
                    _meshRenderer.material.color = Color.blue;
                    break;

                case "red":
                    _meshRenderer.material.color = Color.red;
                    break;

                case "yellow":
                    _meshRenderer.material.color = Color.yellow;
                    break;
            }

            ColorType = colorTypes;
        }
        #endregion Public Methods
    }
}