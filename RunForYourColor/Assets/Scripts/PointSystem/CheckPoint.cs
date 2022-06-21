using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class CheckPoint : Point
    {
        #region Fields
        [SerializeField] private float _speedAddAmount = 1f;
        #endregion Fields

        #region Unity Methods
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_racerTag))
            {
                CharacterStateManager stateManager = other.GetComponent<CharacterStateManager>();

                stateManager.SetCheckPoint(transform);
                SpeedChange(stateManager);
            }
        }
        #endregion Unity Methods

        #region Private Methods
        private void SpeedChange(CharacterStateManager character)
        {
            if (character.ColorType == _colorType)
            {
                character.UpdateSpeed(_speedAddAmount);
            }
            else
            {
                character.UpdateSpeed(-_speedAddAmount);
            }
        }
        #endregion Private Methods
    }
}