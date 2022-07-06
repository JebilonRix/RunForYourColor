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
        #endregion Fields And Properties

        #region Unity Methods
        private void Awake() => _spriteRenderer = GetComponent<SpriteRenderer>();
        private void Start() => _spriteRenderer.sprite = racerInfo.GetRandomName(GetComponentInParent<CharacterStateManager>().IsPlayer);
        #endregion Unity Methods
    }
}