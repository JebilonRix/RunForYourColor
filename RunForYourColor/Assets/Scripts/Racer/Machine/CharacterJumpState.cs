using UnityEngine;

namespace RedPanda.StateMachine
{
    public class CharacterJumpState : CharacterBaseState
    {
        private bool _isJumping = false;
        private float _time = 0;

        public override void EnterState(CharacterStateManager manager)
        {
            _isJumping = true;
            manager.AnimHandler(this);
            manager.SetMass(true);
        }
        public override void UpdateState(CharacterStateManager manager)
        {
            _time += Time.deltaTime;

            if (_time >= manager.Animator.GetCurrentAnimatorClipInfo(0).Length / (30f / 25f))
            {
                manager.SwitchState(manager.FallState);
            }
        }
        public override void FixedUpdateState(CharacterStateManager manager)
        {
            if (_isJumping)
            {
                manager.Rb.AddForce(Vector3.up * manager.JumpForce, ForceMode.Impulse);
                _isJumping = false;
            }

            manager.GoForward();
            manager.WallCheck();

            if (manager.Rb.velocity.y > 2f)
            {
                manager.GroundCheck();
            }
        }
        public override void ExitState(CharacterStateManager manager)
        {
            _isJumping = false;
            _time = 0f;
        }
    }
}