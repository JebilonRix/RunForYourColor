using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class Knockback : MonoBehaviour
    {
        [SerializeField] private Vector3 _knockbackForce = new Vector3(0f, 1f, -500f);
        [SerializeField] private string _tag = "Racer";

        private void Start()
        {
            GetComponent<Collider>().isTrigger = true;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(_tag))
            {
                return;
            }

            CharacterStateManager stateMachine = other.GetComponent<CharacterStateManager>();

            stateMachine.Rb.velocity = Vector3.zero;
            stateMachine.Rb.AddForce(_knockbackForce, ForceMode.Impulse);
        }
    }
}