using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.ObjectPooling
{
    public class SpawnerOnce : BaseSpawner
    {
        #region Fields

        [System.Serializable]
        private struct ObjectAndLocation
        {
            public SO_PooledObject pooledObject;
            public Location location;
        }

        [SerializeField] private List<ObjectAndLocation> _objAndLocList = new List<ObjectAndLocation>();
        #endregion Fields

        #region Unity Methods
        private void Start()
        {
            SpawnObjects();

            //Debug.Log("spawner started");
        }
        #endregion Unity Methods

        #region Public Methods
        public void SpawnObjects()
        {
            foreach (var item in _objAndLocList)
            {
                SpawnRate(item.pooledObject, item.location);
            }
        }
        #endregion Public Methods
    }
}