using System.Collections;
using UnityEngine;

namespace RedPanda.StateMachine
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(MeshRenderer))]
    public class CharacterStateManager : MonoBehaviour
    {
        #region Fields

        #region State
        private CharacterBaseState currentState;
        public CharacterIdleState IdleState = new CharacterIdleState();
        public CharacterRunState RunState = new CharacterRunState();
        public CharacterJumpState JumpState = new CharacterJumpState();
        public CharacterClimbState ClimbState = new CharacterClimbState();
        #endregion State

        [Header("Basic")]
        [SerializeField] private bool _isPlayer;

        [Header("Climbing")]
        [SerializeField] private string _wallTag = "Wall";
        [SerializeField] private float _wallOffset = 1f;

        [Header("Horizontal Movement")]
        [SerializeField] private float _speed = 7;
        [SerializeField] private float _horizontalSpeed = 0.3f;
        [SerializeField] private float _respawnTime = 0.5f;

        [Header("Vertical Movement")]
        [SerializeField] private float _jumpForce = 10;
        [SerializeField] private string _groundTag = "Ground";
        [SerializeField] private float _groundOffSet = 1.1f;
        [SerializeField] private float _minDistanceForJumpInput = 30f;

        [Header("Visual Stuff")]
        [SerializeField] private Animator _animator;

        private string _colorType;
        private float _lastFrameFingerPositionX = 0;
        private float _moveFactorX = 0;
        private bool _startRun = false;
        private Rigidbody _rb;
        private MeshRenderer _meshRenderer;
        private Transform _lastCheckPoint;
        #endregion Fields

        #region Properties
        public Rigidbody Rb { get => _rb; private set => _rb = value; }
        public bool StartRun { get => _startRun; set => _startRun = value; }
        public bool IsPlayer { get => _isPlayer; }
        public string ColorType { get => _colorType; set => _colorType = value; }
        public string GroundTag { get => _groundTag; }
        public float Speed { get => _speed; set => _speed = value; }
        public float JumpForce { get => _jumpForce; }
        public float GroundOffSet { get => _groundOffSet; }
        public float MinDistanceForJumpInput { get => _minDistanceForJumpInput; }
        public Animator Animator { get => _animator; private set => _animator = value; }
        #endregion Properties

        #region Unity Methods
        private void Awake()
        {
            if (Rb == null)
            {
                Rb = GetComponent<Rigidbody>();
            }
            if (Animator == null)
            {
                Animator = GetComponent<Animator>();
            }
            if (_meshRenderer == null)
            {
                _meshRenderer = GetComponent<MeshRenderer>();
            }

            gameObject.tag = "Racer";
        }
        private void Start() => SwitchState(IdleState);
        private void FixedUpdate() => currentState.FixedUpdateState(this);
        private void Update()
        {
            currentState.UpdateState(this);

            if (IsPlayer)
            {
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
            }
            else
            {
                //ToDo: add ai here
            }

            transform.Translate(new Vector3(_moveFactorX * _horizontalSpeed * Time.deltaTime, 0, 0));
            transform.rotation = Quaternion.Euler(0, 0, 0);

            if (Rb.velocity.y == 0)
            {
                Animator.SetBool("FallEnd", true);
            }

            Debug.Log("Current State: " + currentState);
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
        public void GroundCheck()
        {
            if (Physics.Raycast(new Ray(transform.position, Vector3.down), out RaycastHit _hit))
            {
                if (!_hit.collider.CompareTag(GroundTag))
                {
                    return;
                }

                if (_hit.distance <= GroundOffSet)
                {
                    SwitchState(RunState);
                }
            }
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
        public IEnumerator Respawn()
        {
            transform.position = _lastCheckPoint.transform.position;

            SwitchState(IdleState);

            yield return new WaitForSeconds(_respawnTime);

            SwitchState(RunState);
        }
        public void StartRace() => StartRun = true;
        public void SetCheckPoint(Transform checkPoint) => _lastCheckPoint = checkPoint;
        public void UpdateSpeed(float amount) => _speed += amount;
        #endregion Public Methods
    }
}