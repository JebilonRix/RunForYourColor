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

            if (Physics.Raycast(new Ray(manager.transform.position, Vector3.down), out RaycastHit _hit))
            {
                if (!_hit.collider.CompareTag(manager.GroundTag))
                {
                    return;
                }

                if (_hit.distance <= manager.GroundOffSet)
                {
                    manager.SwitchState(manager.RunState);
                }
            }
        }
        public override void ExitState(CharacterStateManager manager)
        {
            _isJumping = false;
        }
    }
}