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
        [SerializeField] private float _horizontalSpeed = 5f;
        private CharacterStateManager _characterStateManager;

        private void Awake()
        {
            _characterStateManager = GetComponent<CharacterStateManager>();
        }
        private void Start()
        {
            FindPoints();
            NextPoint();
        }
        private void Update()
        {
            if (_nextPoint != null)
            {
                //Vector3.MoveTowards(transform.position, _nextPoint.position, Vector3.Distance(transform.position, _nextPoint.position));

                transform.LookAt(_nextPoint);
                transform.rotation.eulerAngles.Set(0, transform.rotation.y, 0);

                if (transform.rotation.y > 0)
                {
                    _characterStateManager.Rb.velocity = new Vector3(_horizontalSpeed, _characterStateManager.Rb.velocity.y, _characterStateManager.Rb.velocity.z);
                }
                else if (transform.rotation.y < 0)
                {
                    _characterStateManager.Rb.velocity = new Vector3(-_horizontalSpeed, _characterStateManager.Rb.velocity.y, _characterStateManager.Rb.velocity.z);
                }

                if (Vector3.Distance(transform.position, _nextPoint.position) == 0)
                {
                    NextPoint();
                }
            }
        }
        public void FindPoints()
        {
            _points.Clear();

            List<RaycastHit> _rayList = Physics.SphereCastAll(transform.position, 1000f, Vector3.forward, _whatPointIs).ToList();

            for (int i = 0; i < _rayList.Count; i++)
            {
                if (!_rayList[i].collider.CompareTag("CheckPoint"))
                {
                    continue;
                }

                _points.Add(_rayList[i].transform);
            }

            _points = _points.OrderBy(p => p.transform.position.z).ToList();
        }
        public void NextPoint()
        {
            if (_points.Count != 0)
            {
                _nextPoint = _points[0];
                _points.RemoveAt(0);
            }
            else
            {
                _nextPoint = _characterStateManager.FinishPoint;
            }
        }
    }
}