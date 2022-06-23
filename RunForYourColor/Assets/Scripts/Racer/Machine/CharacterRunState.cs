using UnityEngine;

namespace RedPanda.StateMachine
{
    public class CharacterRunState : CharacterBaseState
    {
        private float _lastFrameFingerPositionY;

        public override void EnterState(CharacterStateManager manager)
        {
            manager.Rb.useGravity = true;
        }
        public override void UpdateState(CharacterStateManager manager)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastFrameFingerPositionY = Input.mousePosition.y;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                float _moveFactorY = Input.mousePosition.y - _lastFrameFingerPositionY;

                if (manager.MinDistanceForJumpInput <= _moveFactorY)
                {
                    manager.SwitchState(manager.JumpState);
                }
            }
        }
        public override void FixedUpdateState(CharacterStateManager manager)
        {
            manager.Rb.velocity = new Vector3(manager.Rb.velocity.x, manager.Rb.velocity.y, manager.Speed);
            manager.WallCheck();
            manager.GroundCheck();
        }
        public override void ExitState(CharacterStateManager manager)
        {
            _lastFrameFingerPositionY = 0f;
        }
    }
}