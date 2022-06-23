using UnityEngine;

namespace RedPanda.StateMachine
{
    public class CharacterJumpState : CharacterBaseState
    {
        private bool _isJumping = false;

        public override void EnterState(CharacterStateManager manager)
        {
            _isJumping = true;
        }
        public override void UpdateState(CharacterStateManager manager)
        {
        }
        public override void FixedUpdateState(CharacterStateManager manager)
        {
            if (_isJumping)
            {
                manager.Rb.AddForce(Vector3.up * manager.JumpForce, ForceMode.Impulse);
                _isJumping = false;
            }

            manager.WallCheck();
            manager.GroundCheck();
        }
        public override void ExitState(CharacterStateManager manager)
        {
            _isJumping = false;
        }
    }
}