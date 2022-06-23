using UnityEngine;

namespace RedPanda.StateMachine
{
    [RequireComponent(typeof(Animator))]
    public class AnimHandler : MonoBehaviour
    {
        [SerializeField] private CharacterStateManager characterStateManager;
        [SerializeField] private Animator _animator;
        private void Awake()
        {
            if (_animator == null)
            {
                _animator = GetComponent<Animator>();
            }
        }
        private void Update()
        {
            if (characterStateManager.CurrentState == characterStateManager.IdleState)
            {
                _animator.Play("Idle", 0);
            }
            else if (characterStateManager.CurrentState == characterStateManager.RunState)
            {
                _animator.Play("Run", 0);
            }
            else if (characterStateManager.CurrentState == characterStateManager.JumpState)
            {
                _animator.Play("Jump", 0);
            }
            else if (characterStateManager.CurrentState == characterStateManager.FallState)
            {
                _animator.Play("Fall", 0);
            }
            else if (characterStateManager.CurrentState == characterStateManager.ClimbState)
            {
                _animator.Play("Climb", 0);
            }
        }
    }
}