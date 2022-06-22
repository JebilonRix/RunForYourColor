using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class RoadWithColor : Point
    {
        #region Unity Methods
        protected override void OnTriggerEnter(Collider other)
        {
            SpeedChange(other);
        }
        private void OnTriggerExit(Collider other)
        {
            SpeedChange(other);
        }
        #endregion Unity Methods

        #region Private Methods
        private void SpeedChange(Collider other)
        {
            if (other.CompareTag(_racerTag))
            {
                CharacterStateManager racer = other.GetComponent<CharacterStateManager>();

                if (_colorType == racer.ColorType)
                {
                    SpeedChange(racer, 1);
                }
                else
                {
                    SpeedChange(racer, -1);
                }
            }
        }
        #endregion Private Methods
    }
}