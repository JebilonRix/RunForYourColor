using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class DeadPoint : Point
    {
        private CharacterStateManager stateManager;

        private void Start()
        {
            stateManager = FindObjectOfType<CharacterStateManager>();
        }
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_racerTag))
            {
                //CharacterStateManager stateManager = other.GetComponent<CharacterStateManager>();
                stateManager.ToRespawn();

                if (stateManager.IsPlayer)
                {
                    WriteRandomLine(PointType.Dead);
                }
            }
        }
    }
}