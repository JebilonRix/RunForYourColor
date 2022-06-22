using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class DeadPoint : Point
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_racerTag))
            {
                CharacterStateManager stateManager = other.GetComponent<CharacterStateManager>();
                stateManager.StartCoroutine(stateManager.Respawn());

                if (stateManager.IsPlayer)
                {
                    WriteRandomLine(PointType.Dead);
                }
            }
        }
    }
}