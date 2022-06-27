using RedPanda.StateMachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.UI
{
    public class SortingUI : MonoBehaviour
    {
        #region Fields
        [SerializeField] private GameObject _finishPoint;
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _racer1;
        [SerializeField] private GameObject _racer2;
        [SerializeField] private Text _playerSort;

        private float _playerScore;
        private float _racer1Score;
        private float _racer2Score;
        #endregion Fields

        private void Start()
        {
            var racers = FindObjectsOfType<CharacterStateManager>();
            var rac = new GameObject[] { _racer1, _racer2 };

            foreach (var item in racers)
            {
                if (item.IsPlayer)
                {
                    _player = item.gameObject;
                }
                else
                {
                    if (_racer1 == null)
                    {
                        _racer1 = item.gameObject;
                    }
                    else if (_racer2 == null)
                    {
                        _racer2 = item.gameObject;
                    }
                }
            }

            //if (_player == null || _racer1 == null || _racer2 == null)
            //{
            //    for (int i = 0; i < racers.Length; i++)
            //    {
            //        if (racers[i].IsPlayer)
            //        {
            //            _player = racers[i].gameObject;
            //        }

            //        for (int j = 0; j < rac.Length; j++)
            //        {
            //            if (!racers[i].IsPlayer)
            //            {
            //                rac[j] = racers[i].gameObject;
            //            }
            //        }
            //    }
            //}
        }

        #region Public Methods
        public void StartRacers()
        {
            var racer = new List<GameObject>();

            if (_player != null)
            {
                racer.Add(_player);
            }
            if (_racer1 != null)
            {
                racer.Add(_racer1);
            }
            if (_racer2 != null)
            {
                racer.Add(_racer2);
            }

            foreach (var item in racer)
            {
                item.GetComponent<CharacterStateManager>().StartRace();
            }
        }
        public void Sort()
        {
            if (_finishPoint == null)
            {
                return;
            }

            int _sort = 0;

            if (_player != null)
            {
                _playerScore = _finishPoint.transform.position.z - _player.transform.position.z;
            }
            if (_racer1 != null)
            {
                _racer1Score = _finishPoint.transform.position.z - _racer1.transform.position.z;
            }
            if (_racer2 != null)
            {
                _racer2Score = _finishPoint.transform.position.z - _racer2.transform.position.z;
            }

            if (_playerScore < _racer1Score && _playerScore < _racer2Score)
            {
                _sort = 1;
            }
            else if (_playerScore < _racer1Score && _playerScore > _racer2Score)
            {
                _sort = 2;
            }
            else if (_playerScore > _racer1Score && _playerScore < _racer2Score)
            {
                _sort = 2;
            }
            else if (_playerScore > _racer1Score && _playerScore > _racer2Score)
            {
                _sort = 3;
            }

            _playerSort.text = _sort.ToString();
        }
        public void FindFinishPoint(GameObject finishPoint)
        {
            _finishPoint = finishPoint;
        }
        #endregion Public Methods
    }
}