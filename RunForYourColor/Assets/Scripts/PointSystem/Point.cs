using UnityEngine;

namespace RedPanda.PointSystem
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class Point : MonoBehaviour
    {
        [SerializeField] protected string _playerTag = "Player";
        [SerializeField] protected string _racerTag = "Racer";
        [SerializeField] protected ColorTypes _colorType;

        private void Awake()
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }
        protected abstract void OnTriggerEnter(Collider other);
    }
}