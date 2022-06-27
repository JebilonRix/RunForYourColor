using UnityEngine;

namespace RedPanda.PointSystem
{
    public class CheckPoint : Point
    {
        private void Start()
        {
            SetColor();
        }

        #region Unity Methods
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            if (other.CompareTag(_racerTag))
            {
                SortInTrigger();

                _stateManager.SetCheckPoint(transform);
                SpeedChange(_stateManager, _speedAddAmount);

                if (_stateManager.IsPlayer)
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