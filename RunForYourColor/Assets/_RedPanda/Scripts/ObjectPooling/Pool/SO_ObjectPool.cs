using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.ObjectPooling
{
    [CreateAssetMenu(fileName = "Object Pool", menuName = "Red Panda/Object Pool/Object Pool", order = 1)]
    public class SO_ObjectPool : ScriptableObject
    {
        #region Fields
        [SerializeField] private List<SO_PooledObject> _poolList = new List<SO_PooledObject>();

        private readonly Dictionary<string, Queue<GameObject>> _inPool = new Dictionary<string, Queue<GameObject>>();
        private readonly Dictionary<string, Queue<GameObject>> _inUse = new Dictionary<string, Queue<GameObject>>();
        private GameObject parent;
        #endregion Fields

        #region Properties
        public List<SO_PooledObject> PoolList => _poolList;
        #endregion Properties

        #region Unity Methods
        private void OnDisable()
        {
            _poolList = new List<SO_PooledObject>();
        }
        #endregion Unity Methods

        #region Public Methods
        public GameObject GetObject(SO_PooledObject pooledObject, Vector3 position, Vector3 rotation, Transform parent)
        {
            GameObject prefab;

            string tag = pooledObject.PooledObjectTag;

            if (!_inPool.ContainsKey(tag))
            {
                //If pools does not contain the key, this adds the key and queues to the dictionary.
                _inPool.Add(tag, new Queue<GameObject>());
                _inUse.Add(tag, new Queue<GameObject>());
            }

            if (_inPool[tag].Count > 0)
            {
                //if there is the object in pool, this gets the object from pool.
                prefab = _inPool.FromDictionary(tag);
            }
            else
            {
                //else if there is no object in pool, this creates a new object.
                prefab = Instantiate(pooledObject.Prefab);
            }

            //This checks if the object has the interface I_PooledObject.
            prefab.GetComponent<IPooled>().OnStart();

            //This line activates object.
            prefab.SetActive(true);

            //This line adds the object to the in use dictionary.
            _inUse.ToDictionary(tag, prefab);

            //This line sets position and rotation of the object.
            prefab.transform.SetPositionAndRotation(position, Quaternion.Euler(rotation));
            prefab.transform.SetParent(parent);

            return prefab;
        }

        public void RelaseObject(SO_PooledObject pooledObject)
        {
            string tag = pooledObject.PooledObjectTag;

            if (!_inUse.ContainsKey(tag))
            {
                return;
            }

            //This line gets the object from in use dictionary.
            GameObject pooledObj = _inUse.FromDictionary(tag);

            if (pooledObj == null)
            {
                return;
            }

            //This line deactivates the object.
            pooledObj.SetActive(false);

            //This line sets the object to the in pool dictionary.
            _inPool.ToDictionary(tag, pooledObj);

            if (parent == null)
            {
                parent = new GameObject("Garbage Collector")
                {
                    isStatic = true
                };

                DontDestroyOnLoad(parent);
            }

            pooledObj.transform.SetParent(parent.transform);
        }
        public void ReleaseAllObjects()
        {
            foreach (SO_PooledObject pooledObject in PoolList)
            {
                string tag = pooledObject.PooledObjectTag;

                if (!_inUse.ContainsKey(tag))
                {
                    continue;
                }

                int loopCount = _inUse[tag].Count;

                if (loopCount <= 0)
                {
                    continue;
                }

                for (int i = 0; i < loopCount; i++)
                {
                    RelaseObject(pooledObject);
                }
            }
        }
        #endregion Public Methods
    }
}