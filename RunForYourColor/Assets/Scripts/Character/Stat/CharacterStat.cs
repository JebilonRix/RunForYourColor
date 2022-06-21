using RedPanda.PointSystem;
using UnityEngine;

namespace RedPanda.Upgrade
{
    public abstract class CharacterStat : MonoBehaviour
    {
        #region Fields
        [SerializeField] private ColorTypes _colorType;
        #endregion Fields

        #region Properties
        public ColorTypes ColorType { get => _colorType; set => _colorType = value; }
        #endregion Properties

        #region Public Methods
        public abstract void UpdateSpeed(float speed);
        public abstract void StopCharacter();
        #endregion Public Methods
    }
}