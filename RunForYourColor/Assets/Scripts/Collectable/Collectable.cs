//using RedPanda.ObjectPooling;
using UnityEngine;

namespace RedPanda.Collectable
{
    [RequireComponent(typeof(SphereCollider))]
    public class Collectable : MonoBehaviour //, IPooled
    {
        #region Fields
        [SerializeField] private string _tag = "Racer";
        [SerializeField] private int _collectableValue = 1;
        #endregion Fields

        //#region Properties
        //[field: SerializeField] public SO_PooledObject PooledObject { get; set; }
        //#endregion Properties

        #region Unity Methods
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_tag))
            {
                other.GetComponent<Collector>().GainDiamond(_collectableValue);
                //OnRelease();

                gameObject.SetActive(false);
            }
        }
        #endregion Unity Methods

        #region Public Methods
        //public void OnStart()
        //{
        //    SphereCollider col = GetComponent<SphereCollider>();

        //    if (!col.isTrigger)
        //    {
        //        col.isTrigger = true;
        //    }
        //}
        //public void OnRelease()
        //{
        //    PooledObject.RelaseObjectToPool();
        //}
        #endregion Public Methods
    }
}