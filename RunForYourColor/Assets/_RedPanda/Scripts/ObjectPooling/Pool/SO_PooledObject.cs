using UnityEngine;

namespace RedPanda.ObjectPooling
{
    [CreateAssetMenu(fileName = "Pooled Object", menuName = "Red Panda/Object Pool/Pool Object", order = 0)]
    public class SO_PooledObject : ScriptableObject
    {
        #region Fields
        [SerializeField] private string _pooledObjectTag;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private SO_ObjectPool _pool;
        #endregion Fields

        #region Properties
        public string PooledObjectTag => _pooledObjectTag;
        public GameObject Prefab => _prefab;
        public SO_ObjectPool Pool => _pool;
        #endregion Properties

        #region Unity Methods
        private void OnEnable()
        {
            if (_pool == null)
            {
                return;
            }

            if (!_pool.PoolList.Contains(this))
            {
                _pool.PoolList.Add(this);
            }
        }
        #endregion Unity Methods

        #region Public Methods
        /// <summary>
        /// This method is for spawning an object.
        /// </summary>
        public void SetPosition(Vector3 position)
        {
            SetPos(position, Vector3.zero, null);
        }
        public void SetPosition(Vector3 position, Vector3 rotation)
        {
            SetPos(position, rotation, null);
        }
        public void SetPosition(Vector3 position, Vector3 rotation, Transform parent)
        {
            SetPos(position, rotation, parent);
        }
        /// <summary>
        /// This method is for release this object to pool.
        /// </summary>
        public void RelaseObjectToPool()
        {
            Pool.RelaseObject(this);
        }
        #endregion Public Methods

        #region Private Methods
        private void SetPos(Vector3 position, Vector3 rotation, Transform parent)
        {
            Pool.GetObject(this, position, rotation, parent);
        }
        #endregion Private Methods
    }
}