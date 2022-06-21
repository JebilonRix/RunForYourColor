using UnityEngine;

namespace RedPanda
{
    public class GroundCheck : MonoBehaviour
    {
        #region Fields
        [Range(0.01f, 1f)][SerializeField] private float _jumpOffset = 0.25f;
        [SerializeField] private string _groundTag = "Ground";

        private bool _isGrounded = false;
        private RaycastHit _hit;
        #endregion Fields

        #region Properties
        public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }
        #endregion Properties

        #region Unity Methods
        private void Start()
        {
            IsGrounded = false;
        }
        private void Update()
        {
            Ray ray = new Ray(transform.position, Vector3.down);

            if (Physics.Raycast(ray, out _hit))
            {
                if (_hit.collider.CompareTag(_groundTag) && _hit.distance < _jumpOffset)
                {
                    IsGrounded = true;
                }
                else
                {
                    IsGrounded = false;
                }
            }
        }
        #endregion Unity Methods
    }
}