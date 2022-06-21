using System.Collections;
using UnityEngine;

namespace RedPanda.ObjectPooling
{
    public class BaseSpawner : MonoBehaviour
    {
        #region Fields
        [Header("Pool Base")]
        [SerializeField] protected SO_ObjectPool _objectPool;
        [SerializeField] protected bool _isParentThis = false;
        [Header("Limit")]
        [SerializeField] private bool _hasLimit = false;
        [SerializeField] private int _limit = 10;

        protected bool _routunieStarted = false;
        protected bool _startSpawner = false;
        private int _counter = 0;
        #endregion Fields

        #region Properties
        public int Counter
        {
            get
            {
                if (_counter < 0)
                {
                    _counter = 0;
                }

                return _counter;
            }

            set => _counter = value;
        }
        public bool HasLimit { get => _hasLimit; set => _hasLimit = value; }
        #endregion Properties

        #region Public Methods
        public void StartSpawner()
        {
            _startSpawner = true;
        }
        public virtual void StopSpawner()
        {
            _startSpawner = false;
        }
        public virtual void StopSpawnerAndClear()
        {
            _startSpawner = false;
            _counter = 0;
            _objectPool.ReleaseAllObjects();
        }
        public void ReduceCount(int amount)
        {
            _counter -= amount;
        }
        #endregion Public Methods

        #region Private Methods
        protected IEnumerator SpawnRate(SO_PooledObject pooledObject, Location location, float spawnRate)
        {
            //This area is for breaking routine with special reasons.
            if (!_startSpawner || _routunieStarted)
            {
                yield break;
            }
            if (HasLimit && _limit <= Counter)
            {
                yield break;
            }

            _routunieStarted = true;

            yield return new WaitForSeconds(spawnRate);

            //This line is for spawning object.
            _objectPool.GetObject(pooledObject, location.Position, location.Rotation, _isParentThis ? transform : null);

            Counter++;

            _routunieStarted = false;
        }
        protected void SpawnRate(SO_PooledObject pooledObject, Location location)
        {
            _objectPool.GetObject(pooledObject, location.Position, location.Rotation, _isParentThis ? transform : null);
        }
        #endregion Private Methods
    }
}