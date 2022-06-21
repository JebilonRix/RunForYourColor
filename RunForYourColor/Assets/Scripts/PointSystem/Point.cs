using UnityEngine;

namespace RedPanda.PointSystem
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class Point : MonoBehaviour
    {
        #region Fields
        [SerializeField] protected string _racerTag = "Racer";
        [SerializeField] protected string _colorType = "blue";
        #endregion Fields

        #region Unity Methods
        private void Awake()
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }
        protected abstract void OnTriggerEnter(Collider other);
        #endregion Unity Methods
    }
}