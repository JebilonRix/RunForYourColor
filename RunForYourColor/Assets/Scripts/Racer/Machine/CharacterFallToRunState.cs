using UnityEngine;

namespace RedPanda.StateMachine
{
    public class CharacterFallToRunState : CharacterBaseState
    {
        private float _time = 0;

        public override void EnterState(CharacterStateManager manager)
        {
            manager.AnimHandler(this);
        }
        public override void ExitState(CharacterStateManager manager)
        {
            _time = 0;
        }
        public override void FixedUpdateState(CharacterStateManager manager)
        {
        }
        public override void UpdateState(CharacterStateManager manager)
        {
            manager.JumpInput();

            _time += Time.deltaTime;

            if (_time >= manager.Animator.GetCurrentAnimatorClipInfo(0).Length)
            {
                manager.SwitchState(manager.RunState);
            }
        }
    }
}