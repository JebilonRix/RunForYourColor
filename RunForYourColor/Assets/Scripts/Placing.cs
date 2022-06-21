using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.Racing.Placing
{
    public class Placing : MonoBehaviour
    {
        [SerializeField] private Transform _finishPoint;
        [SerializeField] private GameObject[] _racers;
        private float[] distanceToFinish;

        private Dictionary<GameObject, float> _placingDic = new Dictionary<GameObject, float>();

        private void Start()
        {
            ResetPlacing();
        }
        private void Update()
        {
            foreach (GameObject racer in _racers)
            {
                _placingDic[racer] = Vector3.Distance(racer.transform.position, _finishPoint.position);
            }
        }
        public void SetFinishPoint(Transform transform)
        {
            _finishPoint = transform;
        }
        public void ResetPlacing()
        {
            _placingDic.Clear();

            foreach (GameObject racer in _racers)
            {
                _placingDic.Add(racer, Vector3.Distance(racer.transform.position, _finishPoint.position));
            }
        }
        private void PlacingLogic()
        {
            int queue = 0;

            foreach (GameObject racer in _racers)
            {
                _placingDic[racer] = Vector3.Distance(racer.transform.position, _finishPoint.position);
            }



        }
    }
}