using UnityEngine;

namespace RedPanda.StateMachine
{
    public class CharacterRunState : CharacterBaseState
    {
        private float _moveFactorY;
        private float _lastFrameFingerPositionY;

        public override void EnterState(CharacterStateManager manager)
        {
            manager.Rb.useGravity = true;
        }
        public override void UpdateState(CharacterStateManager manager)
        {
            //bura sýkýntýlý hala
            //düþey girdi yani

            if (Input.GetMouseButtonDown(0))
            {
                _lastFrameFingerPositionY = Input.mousePosition.y;
            }
            else if (Input.GetMouseButton(0))
            {
                _moveFactorY = Input.mousePosition.y - _lastFrameFingerPositionY;
                _lastFrameFingerPositionY = Input.mousePosition.y;

                if (1f <= _moveFactorY)
                {
                    manager.SwitchState(manager.JumpState);
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _moveFactorY = 0f;
            }
        }
        public override void FixedUpdateState(CharacterStateManager manager)
        {
            manager.Rb.velocity = new Vector3(manager.Rb.velocity.x, manager.Rb.velocity.y, manager.Speed);
            manager.WallCheck();
        }
        public override void ExitState(CharacterStateManager manager)
        {
            //
        }
    }
}