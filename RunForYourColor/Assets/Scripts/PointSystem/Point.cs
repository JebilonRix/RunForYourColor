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

        //protected SortingUI _sortingUI;
        //protected RandomLine _randomLine;
        protected CharacterStateManager _stateManager;
        #endregion Fields

        #region Unity Methods
        private void Awake() => GetComponent<BoxCollider>().isTrigger = true;
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (_stateManager == null)
            {
                _stateManager = other.GetComponent<CharacterStateManager>();
            }
        }
        #endregion Unity Methods

        #region Private Methods
        protected void SortInTrigger()
        {
            if (!_stateManager.IsPlayer)
            {
                return;
            }

            //if (_sortingUI == null)
            //{
            //    _sortingUI = FindObjectOfType<SortingUI>();
            //}

            //_sortingUI.Sort();
        }
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