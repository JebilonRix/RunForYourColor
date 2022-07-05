using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class RoadWithColor : Point
    {
        #region Unity Methods
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_racerTag) && other.GetComponent<CharacterStateManager>().ColorType == _colorType)
            {
                SpeedChange(other.GetComponent<CharacterStateManager>(), _speedAddAmount);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(_racerTag) && other.GetComponent<CharacterStateManager>().ColorType == _colorType)
            {
                SpeedChange(other.GetComponent<CharacterStateManager>(), -_speedAddAmount);
            }
        }
        #endregion Unity Methods
    }
}