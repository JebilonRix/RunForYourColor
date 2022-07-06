using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RedPanda.StateMachine
{
    [RequireComponent(typeof(CharacterStateManager))]
    public class BotInput : MonoBehaviour
    {
        [SerializeField] private LayerMask _whatPointIs;
        [SerializeField] private List<Transform> _points = new List<Transform>();
        [SerializeField] private Transform _nextPoint;

        private const float _horizontalSpeed = 5f;
        private CharacterStateManager _characterStateManager;

        private void Awake()
        {
            _characterStateManager = GetComponent<CharacterStateManager>();
        }
        private void OnEnable()
        {
            if (_characterStateManager.IsPlayer)
            {
                enabled = false;
            }
        }
        private void Start()
        {
            FindPoints();
            NextPoint();
        }
        private void Update()
        {
            if (_characterStateManager.CurrentState == _characterStateManager.IdleState)
            {
                //Debug.Log("idle state");
                return;
            }
            if (_nextPoint == null)
            {
                //Debug.Log("next point is null");
                return;
            }

            if (transform.position.x - _nextPoint.position.x > 0.25f)
            {
                _characterStateManager.Rb.velocity =
                    new Vector3(-1 * _horizontalSpeed, _characterStateManager.Rb.velocity.y, _characterStateManager.Rb.velocity.z);
            }
            else if (transform.position.x - _nextPoint.position.x < -0.25f)
            {
                _characterStateManager.Rb.velocity =
                    new Vector3(1 * _horizontalSpeed, _characterStateManager.Rb.velocity.y, _characterStateManager.Rb.velocity.z);
            }
            else
            {
                _characterStateManager.Rb.velocity = new Vector3(0f, _characterStateManager.Rb.velocity.y, _characterStateManager.Rb.velocity.z);
            }
        }
        public void FindPoints()
        {
            _points.Clear();

            string tag;

            if (_characterStateManager.ColorType == "blue")
            {
                tag = "Blue";
            }
            else if (_characterStateManager.ColorType == "yellow")
            {
                tag = "Yellow";
            }
            else
            {
                tag = "Red";
            }

            List<RaycastHit> _rayList = Physics.SphereCastAll(transform.position, 1000f, Vector3.forward, _whatPointIs).ToList();

            for (int i = 0; i < _rayList.Count; i++)
            {
                if (_rayList[i].collider.CompareTag(tag) || _rayList[i].collider.CompareTag("FinishPoint"))
                {
                    _points.Add(_rayList[i].transform);
                }
            }

            _points = _points.OrderBy(p => p.transform.position.z).ToList();
        }
        public void NextPoint()
        {
            if (_points.Count == 0)
            {
                return;
            }

            _nextPoint = _points[0];
            _characterStateManager.LastCheckPoint = _nextPoint;
            _points.RemoveAt(0);
        }
    }
}