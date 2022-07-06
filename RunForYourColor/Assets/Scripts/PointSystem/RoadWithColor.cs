using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class RoadWithColor : Point
    {
        [SerializeField] private float speedUpMulti;
        [SerializeField] private float speedDownMulti;

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
                character.UpdateSpeed(_speedAddAmount * speedUpMulti);
            }
            else
            {
                character.UpdateSpeed(-_speedAddAmount * speedDownMulti);
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
                character.UpdateSpeed(-_speedAddAmount * speedDownMulti);
            }
            else
            {
                character.UpdateSpeed(_speedAddAmount * speedUpMulti);
            }
        }
        #endregion Unity Methods
    }
}