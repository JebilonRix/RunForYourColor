using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class RoadWithColor : Point
    {
        #region Unity Methods
        protected override void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(_racerTag))
            {
                return;
            }

            CharacterStateManager character = other.GetComponent<CharacterStateManager>();

            if (character.ColorType == _colorType)
            {
                character.UpdateSpeed(_speedAddAmount);
            }
            else
            {
                character.UpdateSpeed(-_speedAddAmount);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(_racerTag))
            {
                return;
            }

            CharacterStateManager character = other.GetComponent<CharacterStateManager>();

            if (character.ColorType == _colorType)
            {
                character.UpdateSpeed(-_speedAddAmount);
            }
            else
            {
                character.UpdateSpeed(_speedAddAmount);
            }
        }
        #endregion Unity Methods
    }
}