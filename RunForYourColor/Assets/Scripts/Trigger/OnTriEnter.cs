using RedPanda.StateMachine;
using UnityEngine;
using UnityEngine.Events;

namespace RedPanda
{
    public class OnTriEnter : MonoBehaviour
    {
        public UnityEvent _unityEvent;

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Racer"))
            {
                _unityEvent?.Invoke();

                other.GetComponent<CharacterStateManager>().LastCheckPoint = transform;
            }
        }
    }
}