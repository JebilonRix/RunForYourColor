using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda
{
    public class CoilBoing : MonoBehaviour
    {
        [Range(1f, 20f)][SerializeField] private float _jumpForce = 5f;
        private const string _racerTag = "Racer";

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_racerTag))
            {
                other.GetComponent<CharacterStateManager>().Jump(_jumpForce);
            }
        }
    }
}