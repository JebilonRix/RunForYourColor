using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class RoadWithColor : Point
    {
        [SerializeField] private float _speedChange = 5f;

        #region Unity Methods
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_racerTag))
            {
                SpeedChange(other.GetComponent<CharacterStateManager>(), _speedChange);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(_racerTag))
            {
                SpeedChange(other.GetComponent<CharacterStateManager>(), -_speedChange);
            }
        }
        #endregion Unity Methods
    }
}