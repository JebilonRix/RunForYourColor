using RedPanda.StateMachine;
//using RedPanda.UI;
using UnityEngine;

namespace RedPanda.PointSystem
{
    [RequireComponent(typeof(BoxCollider))]
    // [RequireComponent(typeof(MeshRenderer))]
    public abstract class Point : MonoBehaviour
    {
        #region Fields
        [SerializeField] private PointType _type;
        [SerializeField] protected string _racerTag = "Racer";
        [SerializeField] protected string _colorType = "blue";
        [SerializeField] protected float _speedAddAmount = 1f;
        #endregion Fields

        #region Unity Methods
        private void Awake() => GetComponent<BoxCollider>().isTrigger = true;
        #endregion Unity Methods

        #region Private Methods
        protected void SpeedChange(CharacterStateManager character, float speedAmount)
        {
            if (character.ColorType.ToLower() == _colorType.ToLower())
            {
                character.UpdateSpeed(speedAmount);
            }
            else
            {
                character.UpdateSpeed(-speedAmount);
            }
        }
        #endregion Private Methods
    }
}