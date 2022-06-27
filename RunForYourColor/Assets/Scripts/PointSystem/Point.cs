using RedPanda.ObjectPooling;
using RedPanda.StateMachine;
using RedPanda.UI;
using UnityEngine;

namespace RedPanda.PointSystem
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(MeshRenderer))]
    public abstract class Point : MonoBehaviour, IPooled
    {
        protected enum PointType
        {
            Check, Finish, Dead
        }

        #region Fields
        [SerializeField] protected string _racerTag = "Racer";
        [SerializeField] protected string _colorType = "blue";
        [SerializeField] protected float _speedAddAmount = 1f;

        protected SortingUI _sortingUI;
        protected RandomLine _randomLine;
        protected CharacterStateManager _stateManager;

        #region Properties
        [field: SerializeField] public SO_PooledObject PooledObject { get; set; }
        #endregion Properties

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

        #region Public Methods
        public void OnStart()
        {
        }
        public void OnRelease() => PooledObject.RelaseObjectToPool();
        #endregion Public Methods

        #region Private Methods
        protected void SortInTrigger()
        {
            if (_sortingUI == null)
            {
                _sortingUI = FindObjectOfType<SortingUI>();
            }

            _sortingUI.Sort();
        }
        protected void SpeedChange(CharacterStateManager character, float speedAmount)
        {
            if (character.ColorType == _colorType)
            {
                character.UpdateSpeed(speedAmount);
            }
            else
            {
                character.UpdateSpeed(-speedAmount);
            }
        }
        protected void WriteRandomLine(PointType pointType)
        {
            if (_randomLine == null)
            {
                _randomLine = FindObjectOfType<RandomLine>();
            }

            string[] lines = new string[0];

            switch (pointType)
            {
                case PointType.Check:

                    lines = new string[] { "Awesome", "Perfect", "Great" };
                    break;

                case PointType.Finish:
                    lines = new string[] { "Expert Parkourer", "Master Of Parkour", "Master Of Sky" };
                    break;

                case PointType.Dead:
                    lines = new string[] { "Oops" };
                    break;
            }

            _randomLine.TextAnimation(lines[Random.Range(0, lines.Length)]);
        }
        #endregion Private Methods
    }
}