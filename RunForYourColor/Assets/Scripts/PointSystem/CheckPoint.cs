using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.PointSystem
{
    [RequireComponent(typeof(BoxCollider))]
    public class CheckPoint : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Racer"))
            {
                return;
            }

            other.GetComponent<CharacterStateManager>().SetCheckPoint(transform);
        }
    }
}