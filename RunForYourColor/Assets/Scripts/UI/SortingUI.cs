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

        #region Public Methods
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