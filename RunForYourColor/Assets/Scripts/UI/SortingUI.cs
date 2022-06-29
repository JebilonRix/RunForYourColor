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
        [SerializeField] private GameObject _finishUi;

        [SerializeField] private Holder _sortingHolder;
        [SerializeField] private Image _sortImage;

        private float _playerScore;
        private float _racer1Score;
        private float _racer2Score;

        public GameObject FinishUi { get => _finishUi; }
        #endregion Fields

        private void Start()
        {
            var racers = FindObjectsOfType<CharacterStateManager>();

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
                _sortImage.overrideSprite = _sortingHolder.sprites[0];
            }
            else if (_playerScore < _racer1Score && _playerScore > _racer2Score)
            {
                _sortImage.overrideSprite = _sortingHolder.sprites[1];
            }
            else if (_playerScore > _racer1Score && _playerScore < _racer2Score)
            {
                _sortImage.overrideSprite = _sortingHolder.sprites[1];
            }
            else if (_playerScore > _racer1Score && _playerScore > _racer2Score)
            {
                _sortImage.overrideSprite = _sortingHolder.sprites[2];
            }
        }
        public void FindFinishPoint(GameObject finishPoint)
        {
            _finishPoint = finishPoint;
        }
        #endregion Public Methods
    }
}