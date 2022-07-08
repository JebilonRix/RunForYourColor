using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class DeadPoint : Point
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(_racerTag))
            {
                return;
            }

            other.GetComponent<CharacterStateManager>().ToRespawn();
        }
    }
}