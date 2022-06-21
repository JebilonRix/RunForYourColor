using UnityEngine;

namespace RedPanda
{
    public class Swerve : MonoBehaviour
    {
        #region Fields
        [Range(1f, 10f)][SerializeField] private float _forwardSpeed = 3.0f;
        [Range(0.1f, 0.75f)][SerializeField] private float _horizontalSpeed = 0.5f;

        private float _lastFrameFingerPositionX;
        private float _moveFactorX;
        #endregion Fields

        #region Properties
        public float MoveFactorX { get => _moveFactorX; private set => _moveFactorX = value; }
        public float ForwardSpeed { get => _forwardSpeed; set => _forwardSpeed = value; }
        #endregion Properties

        #region Unity Methods
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                MoveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                MoveFactorX = 0f;
            }

            transform.Translate(new Vector3(MoveFactorX * _horizontalSpeed * Time.deltaTime, 0, ForwardSpeed * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        #endregion Unity Methods
    }
}