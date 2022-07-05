using UnityEngine;

namespace RedPanda.StateMachine
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class HeaderHandler : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void Start()
        {
            if (!GetComponentInParent<CharacterStateManager>().IsPlayer)
            {
                _spriteRenderer.sprite = _sprites[Random.Range(0, _sprites.Length)];
            }
        }
    }
}