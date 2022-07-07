using RedPanda.PointSystem;
using RedPanda.SpriteHandler;
using RedPanda.StateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.Sorting
{
    public class SortingManager : MonoBehaviour
    {
        private List<CharacterStateManager> _characterList = new List<CharacterStateManager>();
        private float[] distances;
        private Transform _finishPoint;

        public bool IsStart { get; private set; }

        private void Start()
        {
            var racers = FindObjectsOfType<CharacterStateManager>();
            _finishPoint = FindObjectOfType<FinishPoint>().transform;

            foreach (var rac in racers)
            {
                _characterList.Add(rac);
            }

            distances = new float[_characterList.Count];
        }

        public void StartSorting()
        {
            IsStart = true;
            InvokeRepeating(nameof(Sorting), 0f, 1f);
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


            Debug.Log(index);
            return index;
        }

        private void Sorting()
        {
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = Vector3.Distance(_finishPoint.position, _characterList[i].transform.position);
            }
        }
    }
}