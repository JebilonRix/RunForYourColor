using UnityEngine;
using UnityEngine.Events;

namespace RedPanda
{
    public class OnTriExit : MonoBehaviour
    {
        public UnityEvent _unityEvent;

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Racer"))
            {
                _unityEvent?.Invoke();
            }
        }
    }
}