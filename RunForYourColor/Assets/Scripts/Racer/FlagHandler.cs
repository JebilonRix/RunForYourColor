using RedPanda.SpriteHandler;
using RedPanda.StateMachine;
using UnityEngine;

public class FlagHandler : MonoBehaviour
{
    #region Fields And Properties
    [SerializeField] private SO_SpriteHandler racerInfo;
    private SpriteRenderer _spriteRenderer;
    #endregion Fields And Properties

    #region Unity Methods
    private void Awake() => _spriteRenderer = GetComponent<SpriteRenderer>();
    private void Start() => _spriteRenderer.sprite = racerInfo.GetRandomFlag(GetComponentInParent<CharacterStateManager>().IsPlayer);
    #endregion Unity Methods
}
