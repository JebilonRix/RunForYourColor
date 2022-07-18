using RedPanda.StateMachine;
using UnityEngine;
using UnityEngine.Events;

namespace RedPanda
{
    public class OnTriExit : MonoBehaviour
    {
        [SerializeField] private UnityEvent _unityEvent;
        [SerializeField] private string _colorType;

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Racer"))
            {
                return;
            }
            if (other.GetComponent<CharacterStateManager>().ColorType != _colorType)
            {
                return;
            }

            Invoke(nameof(Delay), 0.5f);
        }

        private void Delay()
        {
            _unityEvent?.Invoke();
        }
    }
}