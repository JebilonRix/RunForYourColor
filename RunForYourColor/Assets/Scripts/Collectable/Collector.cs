using UnityEngine;

namespace RedPanda.Collectable
{
    public class Collector : MonoBehaviour
    {
        #region Fields
        [SerializeField] private int _diamondCount;
        #endregion Fields

        #region Public Methods
        public void GainDiamond(int amount)
        {
            _diamondCount += amount;
        }
        public bool SpendDiamond(int amount)
        {
            if (_diamondCount < amount)
            {
                return false;
            }

            _diamondCount -= amount;
            return true;
        }
        #endregion Public Methods
    }
}