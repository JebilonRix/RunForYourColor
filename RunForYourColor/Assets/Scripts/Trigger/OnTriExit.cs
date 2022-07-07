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
            if (other.CompareTag("Racer") && other.GetComponent<CharacterStateManager>().ColorType == _colorType)
            {
                _unityEvent?.Invoke();
            }
        }
    }
}