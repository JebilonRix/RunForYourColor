using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.ObjectPooling
{
    public class SpawnerOnce : BaseSpawner
    {
        #region Fields

        [SerializeField] private List<ObjectAndLocation> _objAndLocList = new List<ObjectAndLocation>();
        #endregion Fields

        public List<ObjectAndLocation> ObjAndLocList { get => _objAndLocList; }

        #region Unity Methods
        private void Start()
        {
            SpawnObjects();
        }
        #endregion Unity Methods

        #region Public Methods
        public void SpawnObjects()
        {
            foreach (ObjectAndLocation item in ObjAndLocList)
            {
                for (int i = 0; i < item.locations.Count; i++)
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