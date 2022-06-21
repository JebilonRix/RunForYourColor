using UnityEngine;

namespace RedPanda.ObjectPooling
{
    public class PrefabPooled : MonoBehaviour, IPooled
    {
        #region Properties
        [field: SerializeField] public SO_PooledObject PooledObject { get; set; }
        #endregion Properties

        #region Public Methods
        public void OnStart()
        {
            if (PooledObject == null)
            {
                Debug.Log(PooledObject.PooledObjectTag + "'s Scriptable object is not setted to game object");
            }
        }
        public void OnRelease()
        {
            PooledObject.RelaseObjectToPool();
        }
        #endregion Public Methods
    }
}