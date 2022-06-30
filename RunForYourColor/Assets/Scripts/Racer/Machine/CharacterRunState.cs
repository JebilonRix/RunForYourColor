using UnityEngine;

namespace RedPanda.StateMachine
{
    public class CharacterRunState : CharacterBaseState
    {
        public override void EnterState(CharacterStateManager manager)
        {
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
        }
        public override void FixedUpdateState(CharacterStateManager manager)
        {
            manager.GoForward(); //Makes it go forward.

            //Karþýda duvar var mý?
            if (Physics.Raycast(new Ray(manager.transform.position, Vector3.forward), out RaycastHit _wallHit, 2f, manager._whatIsWall))
            {
                if (!_wallHit.transform)
                {
                    return;
                }

                if (_wallHit.distance < manager._wallOffset)
                {
                    manager.SwitchState(manager.ClimbState);
                    return;
                }
            }

            //Altýnda bir þey var mý?
            if (Physics.Raycast(new Ray(manager.transform.position, Vector3.down), out RaycastHit _groundHit, Mathf.Infinity, manager._whatIsWall))
            {
                if (!_groundHit.transform)
                {
                    return;
                }

                if (_groundHit.distance > manager.GroundOffSet)
                {
                    manager.SwitchState(manager.FallState);
                    return;
                }
            }
        }
        public override void ExitState(CharacterStateManager manager)
        {
            manager.FallTime = 0f;
        }
    }
}