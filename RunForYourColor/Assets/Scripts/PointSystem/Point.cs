using RedPanda.ObjectPooling;
using UnityEngine;

namespace RedPanda.PointSystem
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class Point : MonoBehaviour, IPooled
    {
        #region Fields
        [SerializeField] protected string _racerTag = "Racer";
        [SerializeField] protected string _colorType = "blue";

        #endregion Fields

        #region Properties
        [field: SerializeField] public SO_PooledObject PooledObject { get; set; }
        #endregion Properties

        #region Unity Methods
        private void Awake() => GetComponent<BoxCollider>().isTrigger = true;
        protected abstract void OnTriggerEnter(Collider other);

        #endregion Unity Methods

        #region Public Methods
        public void OnStart()
        {
        }
        public void OnRelease() => PooledObject.RelaseObjectToPool();
        #endregion Public Methods
    }
}