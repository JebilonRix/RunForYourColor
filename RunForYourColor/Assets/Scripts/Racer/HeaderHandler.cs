using RedPanda.SpriteHandler;
using UnityEngine;

namespace RedPanda.StateMachine
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class HeaderHandler : MonoBehaviour
    {
        #region Fields And Properties
        [SerializeField] private SO_SpriteHandler racerInfo;
        private SpriteRenderer _spriteRenderer;

        public bool IsPlayer { get; set; }
        public SpriteRenderer RacerSpriteRenderer { get => _spriteRenderer; private set => _spriteRenderer = value; }
        #endregion Fields And Properties

        #region Unity Methods
        private void Awake() => RacerSpriteRenderer = GetComponent<SpriteRenderer>();
        private void Start()
        {
            IsPlayer = GetComponentInParent<CharacterStateManager>().IsPlayer;
            RacerSpriteRenderer.sprite = racerInfo.GetRandomName(IsPlayer);
        }
        #endregion Unity Methods
    }
}