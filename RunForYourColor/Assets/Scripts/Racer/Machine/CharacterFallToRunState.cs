using UnityEngine;

namespace RedPanda.StateMachine
{
    public class CharacterFallToRunState : CharacterBaseState
    {
        private float _time = 0;

        public override void EnterState(CharacterStateManager manager)
        {
            manager.AnimHandler(this); //Sets anim.
        }
        public override void UpdateState(CharacterStateManager manager)
        {
            manager.JumpInput(); //This line checks if there is jump input.

            //Checks end of animation for to enter run state
            if (_time >= manager.Animator.GetCurrentAnimatorClipInfo(0).Length / 2f)
            {
                _time = 0;
                manager.SwitchState(manager.RunState);
            }
            else
            {
                _time += Time.deltaTime;
            }
        }
        public override void FixedUpdateState(CharacterStateManager manager)
        {
            manager.GoForward(); //Makes it go forward.
        }
        public override void ExitState(CharacterStateManager manager)
        {
            _time = 0; //Resets value
        }
    }
}