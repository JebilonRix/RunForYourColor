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
            public Location[] locations;
        }

        [SerializeField] private List<ObjectAndLocation> _objAndLocList = new List<ObjectAndLocation>();
        #endregion Fields

        #region Unity Methods
        private void Start()
        {
            SpawnObjects();
        }
        #endregion Unity Methods

        #region Public Methods
        public void SpawnObjects()
        {
            foreach (ObjectAndLocation item in _objAndLocList)
            {
                for (int i = 0; i < item.locations.Length; i++)
                {
                    SpawnRate(item.pooledObject, item.locations[i]);
                }
            }
        }
        /// <summary>
        /// This method is for editor.
        /// </summary>
        public void ReleaseAll()
        {
            _objectPool.ReleaseAllObjects();

            _objectPool.InPool = new Dictionary<string, Queue<GameObject>>();
            _objectPool.InUse = new Dictionary<string, Queue<GameObject>>();

            PrefabPooled[] prefabs = FindObjectsOfType<PrefabPooled>(true);

            for (int i = 0; i < prefabs.Length; i++)
            {
                DestroyImmediate(prefabs[i].gameObject);
            }
        }
        #endregion Public Methods
    }
}