using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RedPanda.StateMachine
{
    public class BotInput : MonoBehaviour
    {
        [SerializeField] private float _detectionRange = 5f;
        [SerializeField] private LayerMask _whatPointIs;
        private List<Transform> _points = new List<Transform>();
        private Transform _nextPoint;

        private void Start()
        {
            FindPoints();
        }
        private void Update()
        {
            if (_nextPoint != null)
            {
                Vector3.MoveTowards(transform.position, _nextPoint.position, Vector3.Distance(transform.position, _nextPoint.position));

                if (Vector3.Distance(transform.position, _nextPoint.position) < 2f)
                {
                    FindPoints();
                }
            }
        }

        public void FindPoints()
        {
            _points.Clear();

            List<RaycastHit> _rayList = Physics.SphereCastAll(transform.position, _detectionRange, Vector3.forward, _whatPointIs).ToList();

            for (int i = 0; i < _rayList.Count; i++)
            {
                if (_rayList[i].transform.position.z - transform.position.z > 0)
                {
                    _points.Add(_rayList[i].transform);
                }
            }

            _nextPoint = _points[0];
        }
    }
}