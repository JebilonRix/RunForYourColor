using RedPanda.PointSystem;
using RedPanda.StateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.Sorting
{
    public class SortingManager : MonoBehaviour
    {
        #region Fields And Properties
        [SerializeField] private float _calculationRepeat = 0.1f;
        private List<CharacterStateManager> _characterList = new List<CharacterStateManager>();
        private float[] distances;
        private Transform _finishPoint;
        public bool IsStart { get; private set; }
        #endregion Fields And Properties

        #region Unity Methods
        private void Start()
        {
            CharacterStateManager[] racers = FindObjectsOfType<CharacterStateManager>();
            _finishPoint = FindObjectOfType<FinishPoint>().transform;

            foreach (CharacterStateManager rac in racers)
            {
                _characterList.Add(rac);
            }

            distances = new float[_characterList.Count];
        }
        #endregion Unity Methods

        #region Public Methods
        public void StartSorting()
        {
            IsStart = true;
            InvokeRepeating(nameof(Sorting), 0f, _calculationRepeat);
        }
        public void StopSorting()
        {
            IsStart = false;
            CancelInvoke(nameof(Sorting));
        }
        public int WhatIsMyPositionNumber(CharacterStateManager manager)
        {
            float myDistance = Vector3.Distance(_finishPoint.position, manager.transform.position);

            int index = 0;

            for (int i = 0; i < distances.Length; i++)
            {
                if (myDistance - distances[i] > 0)
                {
                    index++;
                }
            }

            if (index > distances.Length - 1)
            {
                index = distances.Length - 1;
            }
            else if (index < 0)
            {
                index = 0;
            }

            return index;
        }
        #endregion Public Methods

        #region Private Methods
        private void Sorting()
        {
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = Vector3.Distance(_finishPoint.position, _characterList[i].transform.position);
            }
        }
        #endregion Private Methods
    }
}