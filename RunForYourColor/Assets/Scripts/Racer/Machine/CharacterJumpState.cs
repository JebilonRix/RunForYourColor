using UnityEngine;

namespace RedPanda.StateMachine
{
    public class CharacterJumpState : CharacterBaseState
    {
        private bool _isJumping = false;
        private float _time = 0;

        public override void EnterState(CharacterStateManager manager)
        {
            _isJumping = true; //Reason of jump force once to object.
            manager.AnimHandler(this); //Sets anim.
        }
        public override void UpdateState(CharacterStateManager manager)
        {
            //Checks end of animation for to enter fall state
            if (_time >= manager.Animator.GetCurrentAnimatorClipInfo(0).Length / 1.2f)
            {
                manager.SwitchState(manager.FallState);
            }
            else
            {
                _time += Time.deltaTime;
            }
        }
        public override void FixedUpdateState(CharacterStateManager manager)
        {
            manager.GoForward(); //Makes it go forward.

            //Karþýda duvar var mý?
            if (Physics.Raycast(new Ray(manager.transform.position, Vector3.forward), out RaycastHit _wallHit, 2f, manager.WhatIsWall))
            {
                if (_wallHit.transform)
                {
                    if (_wallHit.distance < manager._wallOffset)
                    {
                        manager.SwitchState(manager.ClimbState);
                    }
                }
            }

            //Apply jump force once to object.
            if (_isJumping)
            {
                manager.Rb.AddForce(Vector3.up * manager.JumpForce, ForceMode.Impulse);
                _isJumping = false;
            }
        }
        public override void ExitState(CharacterStateManager manager)
        {
            _isJumping = false; //Reset values.
            _time = 0f; //Reset values.
        }
    }
}