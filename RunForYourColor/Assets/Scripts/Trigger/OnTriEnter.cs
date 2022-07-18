using RedPanda.StateMachine;
using UnityEngine;
using UnityEngine.Events;

namespace RedPanda
{
    public class OnTriEnter : MonoBehaviour
    {
        public UnityEvent _unityEvent;
        [SerializeField] private string _colorType = "red";

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Racer"))
            {
                Debug.Log("tag yanl��");
            }

            if (other.GetComponent<CharacterStateManager>().ColorType != _colorType)
            {
                Debug.Log("color type farkl�");
            }

            Debug.Log("a��ld�");
            _unityEvent?.Invoke();
        }
    }
}