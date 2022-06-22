using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class CheckPoint : Point
    {
        #region Unity Methods
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_racerTag))
            {
                SortInTrigger();

                CharacterStateManager stateManager = other.GetComponent<CharacterStateManager>();
                stateManager.SetCheckPoint(transform);
                SpeedChange(stateManager, _speedAddAmount);

                if (stateManager.IsPlayer)
                {
                    WriteRandomLine(PointType.Check); 
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(_racerTag))
            {
                SortInTrigger();
            }
        }
        #endregion Unity Methods
    }
}