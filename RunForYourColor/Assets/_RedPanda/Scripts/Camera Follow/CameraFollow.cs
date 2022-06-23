using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.Camera_Follow
{
    public class CameraFollow : MonoBehaviour
    {
        #region Fields
        [SerializeField] private GameObject _target;
        [SerializeField] private Vector3 _followDistance = new Vector3(0, 4f, -5f);
        [SerializeField] private Vector3 _followRotation = new Vector3(30f, 0, 0);
        #endregion Fields

        private void Start()
        {
            if (_target == null)
            {
                CharacterStateManager[] objs = FindObjectsOfType<CharacterStateManager>();

                for (int i = 0; i < objs.Length; i++)
                {
                    if (objs[i].IsPlayer)
                    {
                        _target = objs[i].gameObject;
                        break;
                    }
                }
            }
        }

        #region Unity Methods
        private void LateUpdate()
        {
            SetPosition();
        }
        #endregion Unity Methods

        #region Public Methods
        public void SetPosition()
        {
            if (_target != null)
            {
                transform.SetPositionAndRotation(_target.transform.position + _followDistance, Quaternion.Euler(_followRotation));
            }
        }
        #endregion Public Methods
    }
}