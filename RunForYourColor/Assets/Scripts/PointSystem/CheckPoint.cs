using RedPanda.UI;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class CheckPoint : Point
    {
        [SerializeField] private RandomLine randomLine;

        #region Unity Methods
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            if (other.CompareTag(_racerTag))
            {
                if (randomLine == null)
                {
                    var x = FindObjectsOfType<RandomLine>(true);

                    foreach (var item in x)
                    {
                        if (item.isRandomLine)
                        {
                            randomLine = item;
                            break;
                        }
                    }
                }

                SortInTrigger();

                _stateManager.SetCheckPoint(transform);

                SpeedChange(_stateManager, _speedAddAmount);

                if (_stateManager.IsPlayer)
                {
                    randomLine.GetRandomText();
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