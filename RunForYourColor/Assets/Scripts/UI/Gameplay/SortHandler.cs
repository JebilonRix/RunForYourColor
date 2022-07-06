using RedPanda.PointSystem;
using RedPanda.StateMachine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RedPanda.UI
{
    public class SortHandler : MonoBehaviour
    {
        #region Fields And Properties
        //[SerializeField] private GameObject[] _lines;
        //private GameObject[] _names;
        //private GameObject[] _flags;

        private Dictionary<float, CharacterStateManager> _sort = new Dictionary<float, CharacterStateManager>();
        private List<CharacterStateManager> _racers = new List<CharacterStateManager>();
        private Transform _finishPoint;
        #endregion Fields And Properties

        #region Unity Methods
        private void Start()
        {
            _finishPoint = FindObjectOfType<FinishPoint>().transform;

            CharacterStateManager[] racers = FindObjectsOfType<CharacterStateManager>();

            foreach (var item in racers)
            {
                _racers.Add(item);
            }

            InvokeRepeating(nameof(Sort), 0f, 1f);

            //SetPosition(false);
        }
        #endregion Unity Methods

        #region Public Methods
        //public void SetPosition(bool sort) => transform.position = sort ? new Vector3(350, 1500, 0) : new Vector3(0, 1920, 0);
        #endregion Public Methods

        #region Private Methods
        private void Sort()
        {
            _sort.Clear();

            for (int i = 0; i < _racers.Count; i++)
            {
                _sort.Add(Vector3.Distance(transform.position, _racers[i].transform.position), _racers[i]);
            }

            //for sorting
            _sort = _sort.OrderByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }
        #endregion Private Methods
    }
}