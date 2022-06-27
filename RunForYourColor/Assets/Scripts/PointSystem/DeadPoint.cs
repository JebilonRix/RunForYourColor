using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class DeadPoint : Point
    {
        protected CharacterStateManager stateManager;

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            if (other.CompareTag(_racerTag))
            {
                stateManager.ToRespawn();

                if (stateManager.IsPlayer)
                {
                    WriteRandomLine(PointType.Dead);
                }
            }
        }
    }
}