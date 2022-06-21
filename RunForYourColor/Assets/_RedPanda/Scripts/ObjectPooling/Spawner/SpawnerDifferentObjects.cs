using UnityEngine;

namespace RedPanda.ObjectPooling
{
    public class SpawnerDifferentObjects : BaseSpawner
    {
        #region Fields
        [Header("Randomize")]
        [SerializeField] private bool _isRandom;
        [SerializeField] private bool _isInOrder;
        [Header("Spawner Specific")]
        [SerializeField] private float _spawnRate = 1f;
        [SerializeField] private SO_PooledObject[] _pooledObject;
        [SerializeField] private Location _location;

        private int _index = -1;
        #endregion Fields

        #region Properties
        public SO_PooledObject PooledObject
        {
            get
            {
                if (_isRandom)
                {
                    return _pooledObject[Random.Range(0, _pooledObject.Length)];
                }
                else if (_isInOrder)
                {
                    Index++;
                    return _pooledObject[Index];
                }
                else
                {
                    return _pooledObject[0];
                }
            }
        }
        public int Index
        {
            get
            {
                if (_index >= _pooledObject.Length)
                {
                    _index = 0;
                }

                return _index;
            }
            private set
            {
                _index = value;
            }
        }
        #endregion Properties

        #region Unity Methods
        private void Awake()
        {
            if (_isRandom && _isInOrder)
            {
                Debug.Log("SpawnerSimpleEditor: Spawner can't be random and in order at the same time.");

                _isRandom = true;
                _isInOrder = false;

                Debug.Log("SpawnerSimpleEditor: Spawner has been changed to random.");
            }
        }
        private void Update()
        {
            if (_startSpawner)
            {
                StartCoroutine(SpawnRate(PooledObject, _location, _spawnRate));
            }
        }
        #endregion Unity Methods

        #region Public Methods
        public override void StopSpawner()
        {
            StopAllCoroutines();
            base.StopSpawner();
        }
        public override void StopSpawnerAndClear()
        {
            StopAllCoroutines();
            base.StopSpawnerAndClear();
        }
        #endregion Public Methods
    }
}