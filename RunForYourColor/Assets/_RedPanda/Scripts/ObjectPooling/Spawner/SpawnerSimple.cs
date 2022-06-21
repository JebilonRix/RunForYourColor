using System.Collections;
using UnityEngine;

namespace RedPanda.ObjectPooling
{
    public class SpawnerSimple : BaseSpawner
    {
        #region Fields
        [Header("Spawner Specific")]
        [SerializeField] private float _spawnRate = 1f;
        [SerializeField] private SO_PooledObject _pooledObject;
        [SerializeField] private Location _location;
        #endregion Fields

        #region Unity Methods
        private void Update()
        {
            if (_startSpawner)
            {
                StartCoroutine(SpawnRate(_pooledObject, _location, _spawnRate));
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