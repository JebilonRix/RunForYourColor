using UnityEngine;

namespace RedPanda.StateMachine
{
    public class CharacterRunState : CharacterBaseState
    {
        public override void EnterState(CharacterStateManager manager)
        {
            Debug.Log("run state");
            manager.AnimHandler(this); //Sets anim.
        }
        public override void UpdateState(CharacterStateManager manager)
        {
            manager.JumpInput(); //This line checks if there is jump input.

            if (manager.Rb.velocity.y != 0)
            {
                if (manager.Rb.velocity.y < -manager.SpeedLimit)
                {
                    manager.FallTime += 0.25f;
                }
                else if (manager.Rb.velocity.y > 1f)
                {
                    manager.FallTime += 0.25f;
                }
                else
                {
                    manager.FallTime += 0.1f;
                }
            }

            if (manager.FallTime > 0.5f)
            {
                manager.SwitchState(manager.FallState);
            }

            //Debug.Log(manager.FallTime);
        }
        public override void FixedUpdateState(CharacterStateManager manager)
        {
            manager.GoForward(); //Makes it go forward.
            manager.WallCheck(); //Checks is there a wall.
        }
        public override void ExitState(CharacterStateManager manager)
        {
            manager.FallTime = 0f;
        }
    }
}