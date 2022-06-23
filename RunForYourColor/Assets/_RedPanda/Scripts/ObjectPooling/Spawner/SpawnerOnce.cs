using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.ObjectPooling
{
    public class SpawnerOnce : BaseSpawner
    {
        [SerializeField]
        private SO_SpawnerOnceHolder _holder;

        //#region Fields
        //[SerializeField] private List<ObjectAndLocation> _objAndLocList;
        //public List<ObjectAndLocation> ObjAndLocList { get => _objAndLocList; }
        //#endregion Fields

        #region Properties
        public SO_SpawnerOnceHolder Holder { get => _holder; }
        #endregion Properties

        #region Unity Methods
        private void Start()
        {
            SpawnObjects();
        }
        #endregion Unity Methods

        #region Public Methods
        public void SpawnObjects()
        {
            foreach (ObjectAndLocation item in Holder.ObjAndLocList)
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
        public void ReleaseAll(PrefabPooled2[] prefabs)
        {
            for (int i = 0; i < prefabs.Length; i++)
            {
                prefabs[i].OnRelease();
            }

            _objectPool.ReleaseAllObjects();
        }
        public void ResetList(PrefabPooled2[] prefabs)
        {
            Holder.ObjAndLocList = new List<ObjectAndLocation>();

            for (int i = 0; i < prefabs.Length; i++)
            {
                prefabs[i].IsAddedToPool = false;
            }
        }
        public void DeleteAndDestroyAll(PrefabPooled2[] prefabs)
        {
            ResetList(prefabs);
            DeleteObjs(prefabs);

            GameObject[] objs = FindObjectsOfType<GameObject>();

            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i].name == "Garbage Collector")
                {
                    DestroyImmediate(objs[i]);
                }
            }
        }
        public void DeleteObjs(PrefabPooled2[] prefabs)
        {
            for (int i = 0; i < prefabs.Length; i++)
            {
                DestroyImmediate(prefabs[i].gameObject);
            }
        }
        public void SeeLevel()
        {
            foreach (ObjectAndLocation item in Holder.ObjAndLocList)
            {
                for (int i = 0; i < item.locations.Count; i++)
                {
                    GameObject obj = Instantiate<GameObject>(item.pooledObject.Prefab, item.locations[i].Position, Quaternion.Euler(item.locations[i].Rotation));
                    obj.transform.localScale = item.locations[i].Scale;
                }
            }
        }
        #endregion Public Methods
    }
}