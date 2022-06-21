using UnityEngine;

namespace RedPanda.ObjectPooling
{
    public class SpawnerSpecificPoints : BaseSpawner
    {
        #region Fields
        [Header("Randomize")]
        [SerializeField] private bool _isRandom = false;
        [Header("Spawner Specific")]
        [SerializeField] private float _spawnRate = 1f;
        [SerializeField] private SO_PooledObject _pooledObject;
        [SerializeField] private Location[] _locations;

        private int _index = -1;
        #endregion Fields

        #region Properties
        public int Index
        {
            get
            {
                if (_index >= _locations.Length)
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
        public Location Locations
        {
            get
            {
                if (_isRandom)
                {
                    return _locations[Random.Range(0, _locations.Length)];
                }
                else
                {
                    Index++;
                    return _locations[Index];
                }
            }
        }
        #endregion Properties

        #region Unity Methods
        private void Update()
        {
            if (_startSpawner)
            {
                StartCoroutine(SpawnRate(_pooledObject, Locations, _spawnRate));
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