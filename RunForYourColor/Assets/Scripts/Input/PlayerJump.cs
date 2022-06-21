using RedPanda.Utils;
using UnityEngine;

namespace RedPanda
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerJump : MonoBehaviour
    {
        #region Fields
        [Header("Connector")]
        [SerializeField] private Camera _cam;
        [SerializeField] private GroundCheck _groundCheck;

        [Header("Jump")]
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private ForceMode _forceMode = ForceMode.Impulse;
        [SerializeField] private float _min = 0f;

        private Rigidbody _rb;
        private bool _jumpForceCanBeActivated;
        private Vector3 _firstPos;
        #endregion Fields

        #region Unity Methods
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
        private void Start()
        {
            _jumpForceCanBeActivated = false;
            _firstPos = new Vector3();
        }
        private void Update()
        {
            if (_groundCheck.IsGrounded && Input.GetMouseButtonDown(0))
            {
                _firstPos = Utils_MousePosition.GetMousePosition(_cam, Input.mousePosition);
            }
            else if (_groundCheck.IsGrounded && Input.GetMouseButtonUp(0))
            {
                Vector3 _endPos = Utils_MousePosition.GetMousePosition(_cam, Input.mousePosition);

                if (_min <= _firstPos.y - _endPos.y)
                {
                    _jumpForceCanBeActivated = true;
                }

                _firstPos = new Vector3();
            }
        }
        private void FixedUpdate()
        {
            if (_jumpForceCanBeActivated)
            {
                _rb.AddForce(Vector3.up * _jumpForce, _forceMode);
                _jumpForceCanBeActivated = false;
            }
        }
        #endregion Unity Methods
    }
}