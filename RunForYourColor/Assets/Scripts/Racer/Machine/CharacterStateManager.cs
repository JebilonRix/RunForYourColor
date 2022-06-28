using System.Collections;
using UnityEngine;

namespace RedPanda.StateMachine
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(Animator))]
    public class CharacterStateManager : MonoBehaviour
    {
        #region Fields

        #region State
        private CharacterBaseState currentState;
        public CharacterIdleState IdleState = new CharacterIdleState();
        public CharacterRunState RunState = new CharacterRunState();
        public CharacterJumpState JumpState = new CharacterJumpState();
        public CharacterClimbState ClimbState = new CharacterClimbState();
        public CharacterFallState FallState = new CharacterFallState();
        public CharacterFallToRunState FallToRunState = new CharacterFallToRunState();
        #endregion State

        [Header("Basic")]
        [SerializeField] private bool _isPlayer;
        [SerializeField] private string _colorType = "blue";

        [Header("Climbing")]
        [SerializeField] private string _climbTag = "ClimbPoint";
        [SerializeField] private string _wallTag = "Wall";
        [SerializeField] private float _wallOffset = 1f;

        [Header("Horizontal Movement")]
        [SerializeField] private float _speed = 15f;
        [SerializeField] private float _horizontalSpeed = 0.3f;
        [SerializeField] private float _respawnTime = 0.5f;

        [Header("Vertical Movement")]
        [SerializeField] private float _jumpForce = 10;
        [SerializeField] private string _groundTag = "Ground";
        [SerializeField] private float _groundOffSet = 1.1f;
        [SerializeField] private float _minDistanceForJumpInput = 30f;
        [SerializeField] private float _speedLimit = 7.5f;

        private float _lastFrameFingerPositionX = 0;
        private float _lastFrameFingerPositionY = 0;
        private float fallTime;
        private float _moveFactorX = 0;
        private bool _startRun = false;
        private Animator _animator;
        private Rigidbody _rb;
        private MeshRenderer _meshRenderer;
        private Transform _lastCheckPoint;
        #endregion Fields

        #region Properties
        public bool StartRun { get => _startRun; set => _startRun = value; }
        public bool IsPlayer { get => _isPlayer; }
        public float Speed { get => _speed; set => _speed = value; }
        public float JumpForce { get => _jumpForce; }
        public float GroundOffSet { get => _groundOffSet; }
        public float MinDistanceForJumpInput { get => _minDistanceForJumpInput; }
        public string ColorType { get => _colorType; set => _colorType = value; }
        public string GroundTag { get => _groundTag; }
        public Animator Animator { get => _animator; private set => _animator = value; }
        public Rigidbody Rb { get => _rb; private set => _rb = value; }
        public CharacterBaseState CurrentState { get => currentState; private set => currentState = value; }
        public float SpeedLimit { get => _speedLimit; }
        public float FallTime { get => fallTime; set => fallTime = value; }
        #endregion Properties

        #region Unity Methods
        private void Awake()
        {
            if (Rb == null)
            {
                Rb = GetComponent<Rigidbody>();
            }
            if (_meshRenderer == null)
            {
                _meshRenderer = GetComponent<MeshRenderer>();
            }
            if (Animator == null)
            {
                Animator = GetComponent<Animator>();
            }

            gameObject.tag = "Racer";
        }
        private void Start() => SwitchState(IdleState);
        private void FixedUpdate() => CurrentState.FixedUpdateState(this);
        private void Update()
        {
            CurrentState.UpdateState(this);

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

            if (_moveFactorX != 0f)
            {
                transform.Translate(new Vector3(_moveFactorX * _horizontalSpeed * Time.deltaTime, 0, 0));
            }
        }
        #endregion Unity Methods

        #region Public Methods
        public void SwitchState(CharacterBaseState state)
        {
            if (CurrentState != null)
            {
                //Exit last state
                CurrentState.ExitState(this);
            }

            //Enter new state
            CurrentState = state;
            CurrentState.EnterState(this);
        }
        public void JumpInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastFrameFingerPositionY = Input.mousePosition.y;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (MinDistanceForJumpInput <= Input.mousePosition.y - _lastFrameFingerPositionY)
                {
                    _lastFrameFingerPositionY = 0f;
                    SwitchState(JumpState);
                }
            }
        }
        public void WallCheck()
        {
            if (Physics.Raycast(new Ray(transform.position, Vector3.forward), out RaycastHit _wallHit))
            {
                if (_wallHit.distance > _wallOffset)
                {
                    return;
                }

                if (_wallHit.collider.CompareTag(_wallTag))
                {
                    SwitchState(ClimbState);
                }
                else if (_wallHit.collider.CompareTag(_climbTag))
                {
                    SwitchState(RunState);
                }
            }
        }
        public void AnimHandler(CharacterBaseState currentState)
        {
            if (currentState == IdleState)
            {
                Animator.Play("Idle", 0);
            }
            else if (currentState == RunState)
            {
                Animator.Play("Run", 0);
            }
            else if (currentState == JumpState)
            {
                Animator.Play("Jump", 0);
            }
            else if (currentState == FallState)
            {
                Animator.Play("Fall", 0);
            }
            else if (currentState == ClimbState)
            {
                Animator.Play("Climb", 0);
            }
            else if (currentState == FallToRunState)
            {
                Animator.Play("FallToRun", 0);
            }
        }
        public void StartRace() => StartRun = true;
        public void UpdateSpeed(float amount) => _speed += amount;
        public void GoForward() => Rb.velocity = new Vector3(0, Rb.velocity.y, Speed);
        public void SetCheckPoint(Transform checkPoint) => _lastCheckPoint = checkPoint;
        public void ToRespawn() => StartCoroutine(Respawn());
        #endregion Public Methods

        #region Private Methods
        private IEnumerator Respawn()
        {
            transform.position = _lastCheckPoint.transform.position;

            yield return new WaitForSeconds(_respawnTime);

            SwitchState(RunState);
        }
        #endregion Private Methods
    }
}